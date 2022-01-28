using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControls : MonoBehaviour
{
    private void Awake()
    {
        print("Hi");
    }
    // Start is called before the first frame update
    void Start()
    {
        InputManager.Escape += Application.Quit;
    }
}
