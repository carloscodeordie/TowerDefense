using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    int numTowers = 0;

    public void AddTower(Waypoint baseWaypoint)
    {
        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
            numTowers++;
        }
        else
        {
            MoveExistingTower();
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate<Tower>(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        var parentTower = GameObject.Find("Towers");
        newTower.transform.parent = parentTower.transform;

        baseWaypoint.isPlaceable = false;
    }

    private void MoveExistingTower()
    {
        Debug.Log("Maximum towers are placed");
    }
}
