using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    // External fields
    [SerializeField] int towerLimit = 3;
    [SerializeField] Tower towerPrefab;

    // Fields declaration
    Queue<Tower> queueTower = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = queueTower.Count;
        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
            numTowers++;
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate<Tower>(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        var parentTower = GameObject.Find("Towers");
        newTower.transform.parent = parentTower.transform;

        baseWaypoint.isPlaceable = false;
        newTower.baseWaypoint = baseWaypoint;

        queueTower.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower = queueTower.Dequeue();

        oldTower.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;

        oldTower.baseWaypoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;

        queueTower.Enqueue(oldTower);
    }
}
