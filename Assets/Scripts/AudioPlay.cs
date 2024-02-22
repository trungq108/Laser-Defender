using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField]  AudioClip shootingSFX;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("TakeDamage")]
    [SerializeField] AudioClip takeDamageSFX;
    [SerializeField][Range(0f, 1f)] float takeDamageVolume = 1f;

    static AudioPlay instance;

    private void Awake()
    {
        ManagerSingleton();
    }

    private void ManagerSingleton()
    {
        if (instance != null)
        {
            this.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingSFX()
    {
        PlayClip(shootingSFX, shootingVolume);
    }

    public void PlayTakeDamageSFX()
    {
        PlayClip(takeDamageSFX, takeDamageVolume);
    }

    private void PlayClip(AudioClip clip,float volume)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
    }
}
