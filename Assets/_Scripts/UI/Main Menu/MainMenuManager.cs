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

    [Header("Audio")]

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clickSFX;
    [SerializeField] AudioClip hoverSFX;

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
        MouseClick();

        if (sceneIndex == 0)
            SceneManager.LoadScene(1);

        gameObject.SetActive(false);

    }

    public void Options()
    {
        MouseClick();
        print("Options");
    }

    public void Quit()
    {
        MouseClick();
        Application.Quit();
        print("Quit");

    }

    public void MouseClick()
    {
        audioSource.volume = 0.75f;
        audioSource.pitch = Random.Range(0.8f, 1.3f);
        audioSource.PlayOneShot(clickSFX);
    }

    public void MouseHover()
    {
        audioSource.volume = 1f;
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(hoverSFX);
    }

    private void ActivateSelf()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0)
            gameObject.SetActive(!gameObject.activeSelf);
    }
}
