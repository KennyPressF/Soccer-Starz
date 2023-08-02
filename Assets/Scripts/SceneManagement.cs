using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement instance;

    [SerializeField] Animator anim;

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(ShowTransitionAnim(sceneIndex));
    }

    IEnumerator ShowTransitionAnim(int sceneIndex)
    {
        anim.SetBool("LoadScene", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneIndex);
        anim.SetBool("LoadScene", false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
