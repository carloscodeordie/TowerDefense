using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    bool isRunning = true;
    
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStart();
        ColorEnd();
        //ExploreNeighbours();
        PathFind();
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

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int exploringCoordinates = startWaypoint.GetGridPosition() + direction;
            
            if (grid.ContainsKey(exploringCoordinates))
            {
                Waypoint nextWaypoint = grid[exploringCoordinates];
                nextWaypoint.SetTopColor(Color.blue);
            }
        }
    }

    private void PathFind()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0)
        {
            Waypoint searchCenter = queue.Dequeue();
            HaltIfEndIsFound(searchCenter);
        }
    }

    private void HaltIfEndIsFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            isRunning = false;
        }
    }
}
