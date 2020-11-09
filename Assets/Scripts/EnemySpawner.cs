using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawn = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Text spawnText;
    [SerializeField] AudioClip spawnedEnemySFX;

    bool isSkipped = false;
    int spawnCounter = 1;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSpawnText();
        StartCoroutine(SpawnEnemies());
    }

    private void UpdateSpawnText()
    {
        spawnText.text = "Score: " + spawnCounter.ToString();
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

                // Update the spawn counter
                spawnCounter++;
                // Update the spawn text
                UpdateSpawnText();

                PlaySound(spawnedEnemySFX);

                yield return new WaitForSeconds(secondsBetweenSpawn);
            }
            else
            {
                isSkipped = true;
                yield return new WaitForSeconds(secondsBetweenSpawn);
            }
        }
    }

    private void PlaySound(AudioClip sound)
    {
        GetComponent<AudioSource>().PlayOneShot(sound);
    }

    private EnemyMovement InstantiateEnemy()
    {
        EnemyMovement instantiatedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        var parentEnemies = GameObject.Find("Enemies");
        instantiatedEnemy.transform.parent = parentEnemies.transform;

        return instantiatedEnemy;
    }
}
