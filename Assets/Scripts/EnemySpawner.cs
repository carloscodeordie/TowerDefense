using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawn = 4f;
    [SerializeField] EnemyMovement enemyPrefab;

    bool isSkipped = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {   
        while (true)
        {

            if (isSkipped)
            {
                Waypoint startWaypoint = enemyPrefab.GetStartWaypoint();
                Waypoint endWaypoint = enemyPrefab.GetEndWaypoint();
                PathFinder enemyPathFinder = enemyPrefab.GetComponent<PathFinder>();

                EnemyMovement instantiatedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                PathFinder newEnemyPathFinder = enemyPrefab.GetComponent<PathFinder>();

                instantiatedEnemy.SetStartWaypoint(startWaypoint);
                instantiatedEnemy.SetEndWaypoint(endWaypoint);

                yield return new WaitForSeconds(secondsBetweenSpawn);
            }
            else
            {
                isSkipped = true;
                yield return new WaitForSeconds(secondsBetweenSpawn);
            }
        }
    }
}
