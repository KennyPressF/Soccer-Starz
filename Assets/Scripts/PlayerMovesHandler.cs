using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovesHandler : MonoBehaviour
{
    Vector3 shotDirection;
    [SerializeField] float shotSpeed;

    BallController ballCtrl;
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        ballCtrl = FindObjectOfType<BallController>();
    }

    public void OnShoot(InputValue action)
    {
        Debug.Log("Shoot");
        if(!player.inPossession) { return; }

        else if (player.inPossession)
        {
            ballCtrl.Shoot(shotDirection, shotSpeed);
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Vertical");
        float verticalInput = Input.GetAxisRaw("Horizontal");

        shotDirection = new Vector3(verticalInput, 0, horizontalInput);
    }
}