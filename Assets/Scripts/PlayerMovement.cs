using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed;
    Vector3 moveDirection;
    Vector3 moveInput;
    Rigidbody rb;

    [Header("Shooting")]
    Vector3 shotDirection;
    [SerializeField] float shotPower;
    [SerializeField] float shotAngle;
    BallController ballCtrl;

    public bool isRedPlayer;

    Player player;
    PlayerAnimationHandler animationHandler;
    MatchController matchController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animationHandler = GetComponent<PlayerAnimationHandler>();
        player = GetComponent<Player>();
        animationHandler = GetComponent<PlayerAnimationHandler>();
        ballCtrl = FindObjectOfType<BallController>();
        matchController = FindObjectOfType<MatchController>();
    }

    private void Start()
    {
        isRedPlayer = player.team == Player.Teams.RedTeam ? true : false;
        player.MoveToStartingPos();
    }

    private void FixedUpdate()
    {
        if (matchController.inPlay != true)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            rb.velocity = moveInput.normalized * moveSpeed * Time.deltaTime;
        }
    }

    private void Update()
    {
        if (matchController.inPlay != true)
        {
            animationHandler.SetRunningAnimation(false);
        }
        else
        {
            shotDirection = new Vector3(moveInput.x, shotAngle, moveInput.y);

            HandleRunningAnim();
        }
    }

    private void OnMove(InputValue input)
    {
        moveInput.x = input.Get<Vector2>().x;
        moveInput.z = input.Get<Vector2>().y;
    }

    public void OnShoot(InputValue action)
    {
        if(matchController.inPlay != true) { return; }

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
