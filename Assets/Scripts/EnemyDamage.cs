using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlesPrefab;
    [SerializeField] ParticleSystem deathParticlesPrefab;

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
        hitParticlesPrefab.Play();
    }

    private void ProcessKill()
    {
        if (hitPoints <= 0)
        {
            var deathVfx = Instantiate(deathParticlesPrefab, transform.position, Quaternion.identity);
            deathVfx.Play();
            Destroy(gameObject);
        }
    }
}
