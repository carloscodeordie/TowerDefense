using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Parameters
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem projectileParticle;

    public Waypoint baseWaypoint;

    // State
    Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {

        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        EnemyDamage[] enemies = FindObjectsOfType<EnemyDamage>();
        if (enemies.Length == 0) { return; }

        EnemyDamage closestEnemy = enemies[0];

        foreach (EnemyDamage enemy in enemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, enemy);
        }

        targetEnemy = closestEnemy.transform;

    }

    private EnemyDamage GetClosestEnemy(EnemyDamage closestEnemy, EnemyDamage enemy)
    {
        float distanceToClosest = Vector3.Distance(closestEnemy.transform.position, gameObject.transform.position);
        float distanceToEnemy = Vector3.Distance(enemy.transform.position, gameObject.transform.position);

        EnemyDamage closests = closestEnemy;
        if (distanceToEnemy < distanceToClosest )
        {
            closests = enemy;
        }

        return closests;
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
