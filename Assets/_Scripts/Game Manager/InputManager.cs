using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static event Action Escape;
    public static event Action PolarityChanged;
    public static event Action Restart;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Escape?.Invoke();

        if (Input.GetMouseButtonDown(1)) {
            PolarityChanged?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart?.Invoke();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
