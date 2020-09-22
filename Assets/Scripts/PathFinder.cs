using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStart();
        ColorEnd();
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            Vector2Int wayPointPos = waypoint.GetGridPosition();
            if (grid.ContainsKey(wayPointPos))
            {
                Debug.LogWarning("Overlapping waypoint: " + waypoint);
            }
            else
            {
                grid.Add(wayPointPos, waypoint);
            }
        }
    }

    private void ColorStart()
    {
        startWaypoint.SetTopColor(Color.green);
    }

    private void ColorEnd()
    {
        endWaypoint.SetTopColor(Color.red);
    }
}
