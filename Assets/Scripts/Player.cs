using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    [SerializeField] float moveSpeed;
    [SerializeField] float rightPadding;
    [SerializeField] float leftPadding;
    [SerializeField] float topPadding;
    [SerializeField] float bottomPadding;

    private void Start()
    {
        InitBound();
    }
    void Update()
    {
        Move();
    }

    void InitBound()
    {
        minBounds = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

    }

    private void Move()
    {
        Vector3 direction = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + direction.x, minBounds.x + leftPadding, maxBounds.x - rightPadding);
        newPos.y = Mathf.Clamp(transform.position.y + direction.y, minBounds.y + bottomPadding, maxBounds.y - topPadding);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        Shooter shooter = GetComponent<Shooter>();        
        shooter.isShooting = value.isPressed;        
    }
}
