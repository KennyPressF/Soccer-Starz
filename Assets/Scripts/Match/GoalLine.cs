using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLine : MonoBehaviour
{
    public enum GoalSide { Left, Right };
    public GoalSide side;

    MatchController matchController;

    private void Awake()
    {
        matchController = FindObjectOfType<MatchController>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Ball"))
        {
            if(side == GoalSide.Right)
            {
                matchController.ProcessGoalScored("redTeam");
            }

            if (side == GoalSide.Left)
            {
                matchController.ProcessGoalScored("blueTeam");
            }
        }
    }
}
