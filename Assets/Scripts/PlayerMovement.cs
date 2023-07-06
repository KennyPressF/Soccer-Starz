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

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animationHandler = GetComponent<PlayerAnimationHandler>();
        player = GetComponent<Player>();
        animationHandler = GetComponent<PlayerAnimationHandler>();
        ballCtrl = FindObjectOfType<BallController>();
    }

    private void Start()
    {
        player.MoveToStartingPos();
    }

    private void FixedUpdate()
    {
        if (MatchController.instance.inPlay != true)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            rb.velocity = moveDirection.normalized * moveSpeed * Time.deltaTime;
        }
    }

    private void Update()
    {
        if (MatchController.instance.inPlay != true)
        {
            animationHandler.SetRunningAnimation(false);
        }
        else
        {
            moveDirection.z = Input.GetAxisRaw("Vertical");
            moveDirection.x = Input.GetAxisRaw("Horizontal");

            shotDirection = new Vector3(moveDirection.x, shotAngle, moveDirection.z);

            HandleRunningAnim();
        }
    }

    public void OnShoot(InputValue action)
    {
        if(MatchController.instance.inPlay != true) { return; }

        if (!player.inPossession) { return; }

        if (player.inPossession)
        {
            ballCtrl.ProcessShoot(shotDirection, shotPower);
            animationHandler.TriggerKick();
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
