using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    bool inPlay;

    [SerializeField] GameObject redPlayer;
    [SerializeField] int redGoals;
    [SerializeField] GameObject bluePlayer;
    [SerializeField] int blueGoals;

    Scoreboard scoreboard;
    Timer timer;

    private void Awake()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
        timer = FindObjectOfType<Timer>();
    }

    private void Start()
    {
        inPlay = true;
    }

    public void ProcessGoalScored(string teamWhoScored)
    {
        if(inPlay)
        {
            if (teamWhoScored == "redTeam")
            {
                redGoals++;
                scoreboard.SetRedGoalsUI(redGoals.ToString());
            }

            if (teamWhoScored == "blueTeam")
            {
                blueGoals++;
                scoreboard.SetBlueGoalsUI(blueGoals.ToString());
            }

            timer.PauseTimer();
            inPlay = false;
            MovePlayersToStartingPos();
        }
    }

    public void MovePlayersToStartingPos()
    {
        //redPlayer.GetComponent<Player>().MoveToStartingPos();
        bluePlayer.GetComponent<Player>().MoveToStartingPos();
    }
}
