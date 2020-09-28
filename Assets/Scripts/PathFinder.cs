using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;
    [SerializeField] bool isRunning = true;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    Waypoint searchCenter;

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

    private void PathFind()
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
            try
            {
                QueueNewNeighbours(exploringCoordinates);
            }
            catch
            {

            }
            /*
            if (grid.ContainsKey(exploringCoordinates))
            {
                Waypoint nextWaypoint = grid[exploringCoordinates];
                nextWaypoint.SetTopColor(Color.blue);
            }
            */
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
}
