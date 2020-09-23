using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class WaypointEditor : MonoBehaviour
{
    // Member variables declaration
    Waypoint waypoint;
    
    // Runs when object before is loaded
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    // Runs every frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    // Functions that makes snapping for waypoints
    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        Vector2 gridPos = waypoint.GetGridPosition();
        this.transform.position = new Vector3(gridPos.x * gridSize, 0f, gridPos.y * gridSize);
    }

    // Functions that updates waypoint name when moving them.
    void UpdateLabel()
    {
        string labelText = waypoint.GetGridPosition().x + "," + waypoint.GetGridPosition().y;

        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = labelText;
        this.gameObject.name = labelText;
    }
}
