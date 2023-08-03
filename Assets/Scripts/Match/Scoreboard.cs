using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI redScoreText;
    [SerializeField] TextMeshProUGUI blueScoreText;

    private void Start()
    {
        ResetGoalsUI();
    }

    public void SetTimerText(int minutes, int seconds)
    {
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timerString;
    }

    public void ResetGoalsUI()
    {
        redScoreText.text = "0";
        blueScoreText.text = "0";
    }

    public void SetRedGoalsUI(string goals)
    {
        redScoreText.text = goals;
    }

    public void SetBlueGoalsUI(string goals)
    {
        blueScoreText.text = goals;
    }
}
