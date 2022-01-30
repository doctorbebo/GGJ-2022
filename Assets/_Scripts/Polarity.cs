using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polarity : MonoBehaviour
{
    [SerializeField] public int currentPolarity = PolarityStates.WHITE;
    public event Action<int> OnPolarityChanged;
    GameObject playerObject;

    private void Start()
    {
        if(gameObject.tag == "Bullet")
        {
            playerObject = GameObject.FindGameObjectWithTag("Player");
            if(playerObject.GetComponent<Polarity>().currentPolarity == PolarityStates.BLACK)
            {
                setPolarity(PolarityStates.BLACK);
            }
        }


    }

    public void setPolarity(int newPolarity)
    {
        currentPolarity = newPolarity;
        OnPolarityChanged?.Invoke(newPolarity);
    }

    public int getPolarity()
    {
        return currentPolarity;
    }
}
