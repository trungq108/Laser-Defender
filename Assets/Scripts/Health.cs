using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem exploredFX;
    [SerializeField] bool isApplyCameraShake;

    Shake cameraShake;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<Shake>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damage damageDealer = other.GetComponent<Damage>();
        if (damageDealer != null)
        {
            PlayHitEffect();
            CameraShake();
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }
    void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        if(health <= 0) { Destroy(gameObject); }
    }
    
    void PlayHitEffect()
    {
        ParticleSystem hitEffect = Instantiate(exploredFX, transform.position, Quaternion.identity);
        Destroy(hitEffect, hitEffect.main.duration + hitEffect.main.startLifetime.constantMax);
    }

    void CameraShake()
    {
        if(cameraShake != null && isApplyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
