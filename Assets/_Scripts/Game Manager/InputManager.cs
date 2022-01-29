using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static event Action Escape;
    public static event Action PolarityChanged;
    public static event Action CauseDamage;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Escape?.Invoke();

        if (Input.GetMouseButtonDown(1)) {
            PolarityChanged?.Invoke();
        }

        // For testing purposes only
        if (Input.GetKeyDown(KeyCode.D)) {
            CauseDamage?.Invoke();
        }
    }
}
