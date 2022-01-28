using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI playResumeText;
    private int sceneIndex;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        InputManager.Escape += ActivateSelf;
    }

    private void OnEnable()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex == 0)
            playResumeText.text = "Play";
        else
            playResumeText.text = "Resume";
    }

    private void OnDisable()
    {
        
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
        gameObject.SetActive(true);
    }
}
