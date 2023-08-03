using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBall : MonoBehaviour
{
    [SerializeField] float lifeDuration;
    [SerializeField] float blinkDuration;
    [SerializeField] float startingForce;
    Vector3 startingDir;

    Rigidbody rb;
    MeshRenderer m_Renderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_Renderer = GetComponent<MeshRenderer>();

        float x = UnityEngine.Random.Range(-2, 2);
        float z = UnityEngine.Random.Range(-2, 2);

        if (x == 0)
            x = FlipCoin() ? -1 : 1;
        if(z == 0)
            z = FlipCoin() ? -1 : 1;

        startingDir = new Vector3(x, 0, z);

        rb.AddForce(startingDir * startingForce, ForceMode.Impulse);

        StartCoroutine(BallLifespan());
    }

    IEnumerator BallLifespan()
    {
        yield return new WaitForSeconds(lifeDuration);
        m_Renderer.enabled = false;
        yield return new WaitForSeconds(blinkDuration);
        m_Renderer.enabled = true;
        yield return new WaitForSeconds(blinkDuration);
        m_Renderer.enabled = false;
        yield return new WaitForSeconds(blinkDuration);
        m_Renderer.enabled = true;
        yield return new WaitForSeconds(blinkDuration);
        m_Renderer.enabled = false;
        yield return new WaitForSeconds(blinkDuration);
        m_Renderer.enabled = true;
        yield return new WaitForSeconds(blinkDuration);
        m_Renderer.enabled = false;
        Destroy(gameObject);
    }

    private bool FlipCoin()
    {
        int x = UnityEngine.Random.Range(0, 1);

        if (x >= 0.5f)
            return true;

        else
            return false;
    }
}
