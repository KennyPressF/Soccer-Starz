using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float elapsedTime;
    [SerializeField] float timerSpeed;
    private bool isPaused;

    Scoreboard scoreboard;

    private void Awake()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
    }

    void Start()
    {
        elapsedTime = 0f;
        //isPaused = false;

        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!isPaused)
        {
            elapsedTime += Time.deltaTime * timerSpeed; ;
            UpdateTimerDisplay();
        }

        if(elapsedTime > 180f)
        {
            var matchCtrl = MatchController.instance;

            if (matchCtrl.redGoals > matchCtrl.blueGoals)
            {
                matchCtrl.EndGame("redTeam");
            }

            else if (matchCtrl.blueGoals > matchCtrl.redGoals)
            {
                matchCtrl.EndGame("blueTeam");
            }

            else if (matchCtrl.blueGoals == matchCtrl.redGoals)
            {
                matchCtrl.EndGame("tie");
            }
        }
    }

    public void PauseTimer()
    {
        isPaused = true;
    }

    public void UnpauseTimer()
    {
        isPaused = false;
    }

    public void ResetTimer()
    {
        isPaused = false;
        elapsedTime = 0f;
        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        scoreboard.SetTimerText(minutes, seconds);
    }
}

