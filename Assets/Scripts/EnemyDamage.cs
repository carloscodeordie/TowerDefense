using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        ProcessKill();
    }

    private void ProcessHit()
    {
        hitPoints--;
    }

    private void ProcessKill()
    {
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
