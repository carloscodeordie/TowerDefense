using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlesPrefab;
    [SerializeField] ParticleSystem deathParticlesPrefab;
    [SerializeField] AudioClip hitEnemySFX;

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
        PlaySound(hitEnemySFX);
    }

    private void ProcessKill()
    {
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        var deathVfx = Instantiate(deathParticlesPrefab, transform.position, Quaternion.identity);
        var parentEnemies = GameObject.Find("VFX");
        deathVfx.transform.parent = parentEnemies.transform;

        deathVfx.Play();

        Destroy(deathVfx.gameObject, deathVfx.main.duration);
        Destroy(gameObject);
    }

    private void PlaySound(AudioClip sound)
    {
        GetComponent<AudioSource>().PlayOneShot(sound);
    }
}
