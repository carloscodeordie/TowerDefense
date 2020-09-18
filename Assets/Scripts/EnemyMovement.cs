using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    private IEnumerator FollowPath()
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
