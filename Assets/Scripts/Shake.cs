using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1.0f;
    [SerializeField] float shakeManituge = 5.0f;

    Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(CameraShake());
    }

    IEnumerator CameraShake()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = initialPosition + Random.insideUnitSphere * shakeManituge;
            yield return new WaitForEndOfFrame();           
        }
        transform.position = initialPosition;
    }
}
