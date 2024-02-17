using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Shooter : MonoBehaviour
{
    public bool isShooting;
    Coroutine shooting;

    [SerializeField] GameObject laserPrefabs;
    [SerializeField] float laserSpeed = 5f;
    [SerializeField] float laserLifeTime = 3f;
    [SerializeField] float firingRate;
    [SerializeField] bool useAI;

    private void Start()
    {
        if(useAI) { isShooting = true; }
    }

    private void Update()
    {
        if (isShooting && shooting == null)
        {
            shooting = StartCoroutine(ContinueShooting());
        }
        else if (!isShooting && shooting != null) 
        { 
            StopCoroutine(shooting); 
            shooting = null;
        }
    }

    IEnumerator ContinueShooting()
    {  
        while (true)
        {
            GameObject laser = Instantiate(laserPrefabs, transform.position, Quaternion.identity);
            Rigidbody2D laserRb = laser.GetComponent<Rigidbody2D>();
            laserRb.velocity = transform.up * laserSpeed;
            Destroy(laser, laserLifeTime);
            yield return new WaitForSeconds(ShootingRate());
        }             
    }

    private float ShootingRate()
    {
        float shootingRateVarian = 0.5f;
        float aiShootingRate = Random.Range(firingRate - shootingRateVarian, firingRate + shootingRateVarian);
        if (useAI)
        {
            return Mathf.Clamp(aiShootingRate, Mathf.Epsilon, float.MaxValue);
        }
        else { return firingRate; }
    }
}
