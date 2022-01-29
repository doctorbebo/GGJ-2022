using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static event Action Escape;
    public static event Action<int> PolaritySwitched;

    // Might not be the best place for this, but it works for now.
    private int currentPolarity = PolarityStates.WHITE;

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

        if (Input.GetKeyDown(KeyCode.E)) {
            currentPolarity = (currentPolarity + 1) % PolarityStates.STATES.Length;

            PolaritySwitched?.Invoke(currentPolarity);
        }
    }
}
