using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] Vector2 scrollDirection;
    Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        Vector2 offset = scrollDirection * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
