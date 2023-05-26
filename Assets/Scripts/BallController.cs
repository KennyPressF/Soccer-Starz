using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ProcessShoot(Vector3 shotDir, float shotPower)
    {
        rb.AddForce(shotDir * shotPower, ForceMode.Impulse);
    }
}
