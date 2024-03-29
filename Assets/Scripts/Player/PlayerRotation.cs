using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerRotation : MonoBehaviour
{
    Vector3 rotateDirection;
    [SerializeField] float rotateSpeed;

    MatchController matchController;

    private void Awake()
    {
        matchController = FindObjectOfType<MatchController>();
    }

    void Update()
    {
        if (matchController.inPlay != true) { return; }

        float horizontalInput = Input.GetAxisRaw("Vertical");
        float verticalInput = Input.GetAxisRaw("Horizontal");

        rotateDirection = new Vector3(verticalInput, 0, horizontalInput);

        if (rotateDirection.sqrMagnitude > 0.001f)
        {
            var desiredRotation = Quaternion.LookRotation(rotateDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotateSpeed * Time.deltaTime);
        }
    }
}
