using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Constant declaration
    const int gridSize = 10;

    // Member declaration
    Vector2Int gridPos;

    // Get Grid Size used by Waypoint
    public int GetGridSize()
    {
        return gridSize;
    }

    // Get Grid Position of the Waypoint
    public Vector2Int GetGridPosition()
    {
        int xPos = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        int zPos = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        return new Vector2Int(xPos, zPos);
    }

    // Set Top Color of Waypoint
    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
