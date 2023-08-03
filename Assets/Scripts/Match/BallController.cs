using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] Vector3 ballStartPos;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ResetBallPos();
    }

    public void ProcessShoot(Vector3 shotDir, float shotPower)
    {
        rb.AddForce(shotDir * shotPower, ForceMode.Impulse);
    }

    public void ResetBallPos()
    {
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        transform.position = ballStartPos;
        rb.isKinematic = false;
    }
}
