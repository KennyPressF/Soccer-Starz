using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class MatchController : MonoBehaviour
{
    public bool inPlay;

    [SerializeField] GameObject redPlayer;
    public int redGoals;
    [SerializeField] GameObject bluePlayer;
    public int blueGoals;

    [SerializeField] int maxGoals;

    [SerializeField] GameObject goalAnim;
    [SerializeField] GameObject countdownAnim;

    BallController ballController;
    Scoreboard scoreboard;
    Timer timer;

    public static MatchController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this.gameObject);
        }

        ballController = FindObjectOfType<BallController>();
        scoreboard = FindObjectOfType<Scoreboard>();
        timer = FindObjectOfType<Timer>();
    }

    private void Start()
    {
        timer.PauseTimer();
        goalAnim.SetActive(false);
        countdownAnim.SetActive(false);
        StartCoroutine(ProcessCountdownToPlay());
    }

    public void ProcessGoalScored(string teamWhoScored)
    {
        if(inPlay)
        {
            if (teamWhoScored == "redTeam")
            {
                redGoals++;
                scoreboard.SetRedGoalsUI(redGoals.ToString());
                CheckForGameEnd("redTeam", redGoals);
            }

            if (teamWhoScored == "blueTeam")
            {
                blueGoals++;
                scoreboard.SetBlueGoalsUI(blueGoals.ToString());
                CheckForGameEnd("blueTeam", blueGoals);
            }

            timer.PauseTimer();
            inPlay = false;
        }
    }

    public void MovePlayersToStartingPos()
    {
        //redPlayer.GetComponent<Player>().MoveToStartingPos();
        bluePlayer.GetComponent<Player>().MoveToStartingPos();
    }

    private void CheckForGameEnd(string team, int goalsScored)
    {
        if(goalsScored >= maxGoals)
        {
            EndGame(team);
        }
        else
        {
            StartCoroutine(ProcessGoalTransition());
        }
    }

    public void EndGame(string winningTeam)
    {
        timer.PauseTimer();
        inPlay = false;

        switch(winningTeam)
        {
            case "redTeam":
                Debug.Log("Red Team Wins!");
                break;

            case "blueTeam":
                Debug.Log("Blue Team Wins!");
                break;

            case "tie":
                Debug.Log("Tie Game!");
                break;

            default:
                Debug.Log("Error in End Game method of MatchController.cs");
                break;
        }
    }

    IEnumerator ProcessGoalTransition()
    {
        goalAnim.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        ballController.ResetBallPos();
        MovePlayersToStartingPos();
        yield return new WaitForSeconds(2f);
        goalAnim.SetActive(false);
        StartCoroutine(ProcessCountdownToPlay());
    }

    IEnumerator ProcessCountdownToPlay()
    {
        countdownAnim.SetActive(true);
        yield return new WaitForSeconds(3f);
        countdownAnim.SetActive(false);
        inPlay = true;
        timer.UnpauseTimer();
    }
}
