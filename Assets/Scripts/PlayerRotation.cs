using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    void Update()
    {
        //transform.LookAt(ballPos);

        float horizontalInput = Input.GetAxis("Vertical");
        float verticalInput = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(verticalInput, 0, horizontalInput);

        if (moveDirection.sqrMagnitude > 0.001f)
        {
            var desiredRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotateSpeed * Time.deltaTime);
        }
    }
}
