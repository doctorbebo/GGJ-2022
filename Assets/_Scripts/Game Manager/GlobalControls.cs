using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
