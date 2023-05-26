using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovesHandler : MonoBehaviour
{
    Vector3 shotDirection;
    [SerializeField] float shotPower;
    [SerializeField] float shotAngle;

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
            //ballCtrl.Shoot(shotDirection, shotSpeed);
            ballCtrl.ProcessShoot(shotDirection, shotPower);
        }

        else
        {
            //tackle
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Vertical");
        float verticalInput = Input.GetAxisRaw("Horizontal");

        shotDirection = new Vector3(verticalInput, shotAngle, horizontalInput);
    }
}
