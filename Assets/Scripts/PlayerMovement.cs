using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed;
    Vector3 moveDirection;
    Vector2 moveInput;
    Rigidbody rb;

    [Header("Shooting")]
    Vector3 shotDirection;
    [SerializeField] float shotPower;
    [SerializeField] float shotAngle;
    BallController ballCtrl;


    Player player;
    PlayerAnimationHandler animationHandler;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animationHandler = GetComponent<PlayerAnimationHandler>();
        player = GetComponent<Player>();
        animationHandler = GetComponent<PlayerAnimationHandler>();
        ballCtrl = FindObjectOfType<BallController>();
    }

    //void OnMove(InputValue input)
    //{
    //    moveInput = input.Get<Vector2>();
    //    moveDirection.x = moveInput.x;
    //    moveDirection.z = moveInput.y;
    //}

    private void FixedUpdate()
    {
        rb.velocity = moveDirection.normalized * moveSpeed * Time.deltaTime;
    }

    private void Update()
    {
        moveDirection.z = Input.GetAxisRaw("Vertical");
        moveDirection.x = Input.GetAxisRaw("Horizontal");

        shotDirection = new Vector3(moveDirection.x, shotAngle, moveDirection.z);

        HandleRunningAnim();
    }

    public void OnShoot(InputValue action)
    {
        if (!player.inPossession) { return; }
        Debug.Log("Shoot");
        
        if (player.inPossession)
        {
            ballCtrl.ProcessShoot(shotDirection, shotPower);
            animationHandler.TriggerKick();
        }

        else
        {
            //tackle
        }
    }

    private void HandleRunningAnim()
    {
        if (rb.velocity != Vector3.zero)
        {
            animationHandler.SetRunningAnimation(true);
        }
        else
        {
            animationHandler.SetRunningAnimation(false);
        }
    }
}
