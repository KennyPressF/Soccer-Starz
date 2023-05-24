using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    Player player;
    BallController ballCtrl;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        ballCtrl = FindObjectOfType<BallController>();
        rb = GetComponent<Rigidbody>();
    }

    public void Shoot(Vector3 shotDir, float shotPower)
    {
        rb.AddForce(shotDir * shotPower, ForceMode.Impulse);
    }
}
