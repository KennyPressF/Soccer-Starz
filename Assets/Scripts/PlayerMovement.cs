using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector3 moveDirection;
    Vector2 moveInput;
    Rigidbody rb;

    GameObject ball;
    [SerializeField] GameObject ballPoint;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
        moveDirection.x = moveInput.x;
        moveDirection.z = moveInput.y;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection.normalized * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Ball"))
        {
            ball = collision.gameObject;
            ball.transform.SetParent(ballPoint.transform);
            ball.transform.localPosition = Vector3.zero;
        }
    }
}
