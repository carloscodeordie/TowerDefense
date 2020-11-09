using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = 0.5f;
    [SerializeField] ParticleSystem goalParticle;

    // Start is called before the first frame update
    void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    private IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waipoint in path)
        {
            transform.position = waipoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        var goalVfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        var parentVFX = GameObject.Find("VFX");
        goalVfx.transform.parent = parentVFX.transform;

        goalVfx.Play();
        
        Destroy(goalVfx.gameObject, goalVfx.main.duration);
        Destroy(gameObject);
    }

    public Waypoint GetStartWaypoint()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        return pathFinder.GetStartWaypoint();
    }

    public Waypoint GetEndWaypoint()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        return pathFinder.GetEndWaypoint();
    }

    public void SetStartWaypoint(Waypoint start)
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        pathFinder.SetStartWaypoint(start);
    }

    public void SetEndWaypoint(Waypoint end)
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        pathFinder.SetEndWaypoint(end);
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
