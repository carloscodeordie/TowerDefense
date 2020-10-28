using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;
    [SerializeField] Tower towerPrefab;

    // Constant declaration
    const int gridSize = 10;

    // Public members
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    // Member declaration
    Vector2Int gridPos;

    private void Start()
    {
        Physics.queriesHitTriggers = true;
    }

    private void Update()
    {
        if (isExplored)
        {
            SetTopColor(exploredColor);
        }
    }

    // Get Grid Size used by Waypoint
    public int GetGridSize()
    {
        return gridSize;
    }

    // Get Grid Position of the Waypoint
    public Vector2Int GetGridPosition()
    {
        int xPos = Mathf.RoundToInt(transform.position.x / gridSize);
        int zPos = Mathf.RoundToInt(transform.position.z / gridSize);

        return new Vector2Int(xPos, zPos);
    }

    // Set Top Color of Waypoint
    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                InstantiateTower();
                isPlaceable = false;
            }
            else
            {
                print("Tower cannot be placed here");
            }
            
        }
    }

    private void InstantiateTower()
    {
        var newTower = Instantiate<Tower>(towerPrefab, transform.position, Quaternion.identity);
        var parentTower = GameObject.Find("Towers");
        newTower.transform.parent = parentTower.transform;
    }
}
