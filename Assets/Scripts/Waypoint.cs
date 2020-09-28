﻿using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;

    // Constant declaration
    const int gridSize = 10;

    // Public members
    public bool isExplored = false;
    public Waypoint exploredFrom;

    // Member declaration
    Vector2Int gridPos;

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
}
