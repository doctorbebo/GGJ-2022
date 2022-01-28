using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Play()
    {
        print("Play");
        SceneManager.LoadScene(1);
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
}
