using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem exploredFX;
    [SerializeField] bool isApplyCameraShake;
    [SerializeField] int enemyPoint = 50;
    [SerializeField] bool isPlayer;

    Shake cameraShake;
    AudioPlay audioPlay;
    ScoreKeeper scoreKeeper;
    SceneControl sceneControl;

    private void Awake()
    {
        sceneControl = FindObjectOfType<SceneControl>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        audioPlay = FindObjectOfType<AudioPlay>();
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
        if (health <= 0) { Die(); }
    }

    void Die()
    {
        if (!isPlayer) { scoreKeeper.AddScore(enemyPoint); }
        else { sceneControl.LoadGameOverScene(); }      
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        audioPlay.PlayTakeDamageSFX();
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

    public int GetHealthNumber()
    {
        return health;
    }
}
