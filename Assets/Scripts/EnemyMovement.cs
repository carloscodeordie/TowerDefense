using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    private IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol");
        foreach (Waypoint waipoint in path)
        {
            transform.position = waipoint.transform.position;
            print("Patrol in position: " + waipoint.name);
            yield return new WaitForSeconds(1f);
        }
        print("End patrol");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
