using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject prevButton;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject menuButton;
    Button buttonComp;
    TextMeshProUGUI buttonText;

    [SerializeField] string[] buttonTextArray;
    int index;

    private void Start()
    {
        prevButton.GetComponent<Button>().onClick.AddListener(delegate { PreviousButton(); });
        nextButton.GetComponent<Button>().onClick.AddListener(delegate { NextButton(); });
        menuButton.GetComponent<Button>().onClick.AddListener(delegate { ProcessClick(); });

        buttonText = menuButton.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = buttonTextArray[index];
    }

    private void PreviousButton()
    {
        index--;

        if(index < 0)
        {
            index = buttonTextArray.Length - 1;
        }
        
        buttonText.text = buttonTextArray[index];
    }
    
    private void NextButton()
    {
        index++;

        if(index > buttonTextArray.Length -1)
        {
            index = 0;
        }

        buttonText.text = buttonTextArray[index];
    }

    private void ProcessClick()
    {
        switch (index)
        {
            case 0:
                StartNewGame();
                break;

            case 1:
                ShowOptions();
                break;

            case 2:
                SceneManagement.instance.QuitGame();
                break;

            default:
                break;
        }
    }

    private void StartNewGame()
    {
        SceneManagement.instance.LoadScene(1);
    }

    private void ShowOptions()
    {
        Debug.Log("Show Options");
    }
}
