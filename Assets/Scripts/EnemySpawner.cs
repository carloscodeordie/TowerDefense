using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawn = 2f;
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

                EnemyMovement instantiatedEnemy = InstantiateEnemy();

                instantiatedEnemy.SetActive(true);
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

    private EnemyMovement InstantiateEnemy()
    {
        EnemyMovement instantiatedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        var parentEnemies = GameObject.Find("Enemies");
        instantiatedEnemy.transform.parent = parentEnemies.transform;

        return instantiatedEnemy;
    }
}
