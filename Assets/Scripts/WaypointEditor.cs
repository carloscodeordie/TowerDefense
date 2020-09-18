using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class WaypointEditor : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;

    TextMesh textMesh;

    private void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();
    }

    void Update()
    {
        MoveInGrid();
    }

    void MoveInGrid()
    {
        Vector3 snapPos = CalculateGridPosition();
        this.transform.position = snapPos;
    }

    private Vector3 CalculateGridPosition()
    {
        float posX = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        float posZ = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        PrintPosition(posX, posZ);

        return new Vector3(posX, 0f, posZ);
    }

    void PrintPosition(float posX, float posZ)
    { 
        string labelText = posX / gridSize + "," + posZ / gridSize;
        textMesh.text = labelText;

        RenameWaypoint(labelText);
    }

    void RenameWaypoint(string name)
    {
        this.gameObject.name = name;
    }
}
