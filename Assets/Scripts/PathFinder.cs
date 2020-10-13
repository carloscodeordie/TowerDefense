using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    // Serializable parameters
    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;
    [SerializeField] bool isRunning = true;

    // Instance members
    List<Waypoint> path = new List<Waypoint>();
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    Waypoint searchCenter;

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }

        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        ColorStart();
        ColorEnd();
        BreadthFirstSearch();
        CreatePath();
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

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndIsFound();
            ExploreNeighbours();

            searchCenter.isExplored = true;
        }
    }

    private void HaltIfEndIsFound()
    {
        if (searchCenter == endWaypoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int exploringCoordinates = searchCenter.GetGridPosition() + direction;
            if (grid.ContainsKey(exploringCoordinates))
            {
                QueueNewNeighbours(exploringCoordinates);
            }   
        }
    }

    private void QueueNewNeighbours(Vector2Int exploringCoordinates)
    {
        Waypoint neighbour = grid[exploringCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {

        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);

        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startWaypoint);
        path.Reverse();
    }
}
