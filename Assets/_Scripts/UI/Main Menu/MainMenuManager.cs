using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private static MainMenuManager instance;
    public TextMeshProUGUI playResumeText;
    private int sceneIndex;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        InputManager.Escape += ActivateSelf;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex == 0)
            playResumeText.text = "Play";
        else
            playResumeText.text = "Resume";

        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;        
    }

    private void OnDestroy()
    {
        InputManager.Escape -= ActivateSelf;
    }

    public void PlayResume()
    {
        if (sceneIndex == 0)
            SceneManager.LoadScene(1);

        gameObject.SetActive(false);
    }

    public void Options()
    {
        print("Options");
    }

    public void Quit()
    {
        Application.Quit();
        print("Quit");
    }

    private void ActivateSelf()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0)
            gameObject.SetActive(!gameObject.activeSelf);
    }
}
