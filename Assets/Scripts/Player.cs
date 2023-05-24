using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Teams { Team1, Team2};
    public Teams team;

    public bool inPossession;

    public void SetPossession(bool boolReturn)
    {
        inPossession = boolReturn;
    }
}
