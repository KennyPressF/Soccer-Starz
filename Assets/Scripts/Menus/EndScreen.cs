using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreen : MonoBehaviour
{
    int x;
    [SerializeField] TextMeshProUGUI resultText;

    [SerializeField] GameObject newGameButton;
    [SerializeField] GameObject mainMenuButton;
    [SerializeField] GameObject quitButton;

    private void Start()
    {
        newGameButton.GetComponent<Button>().onClick.AddListener(delegate { SceneManagement.instance.LoadScene(1); });
        mainMenuButton.GetComponent<Button>().onClick.AddListener(delegate { SceneManagement.instance.LoadScene(0); });
        quitButton.GetComponent<Button>().onClick.AddListener(delegate { SceneManagement.instance.QuitGame(); });

        x = PlayerPrefs.GetInt("gameResult");

        switch(x)
        {
            //Red Win
            case 0:
                resultText.text = "Red Team Wins";
                break;

            //Blue Win
            case 1:
                resultText.text = "Blue Team Wins";
                break;

            //Tie
            case 2:
                resultText.text = "Tie Game";
                break;

            default:
                Debug.Log("Default case of Switch statement raised in EndScreen.cs");
                break;
        }
    }
}
