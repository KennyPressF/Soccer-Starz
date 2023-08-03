using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Teams { RedTeam, BlueTeam};
    public Teams team;

    [SerializeField] Vector3 startingPosition;
    [SerializeField] Vector3 startingRotation;

    public bool inPossession;

    public void SetPossession(bool boolReturn)
    {
        inPossession = boolReturn;
    }

    public void MoveToStartingPos()
    {
        transform.position = startingPosition;
        transform.rotation = Quaternion.Euler(startingRotation);
    }
}
