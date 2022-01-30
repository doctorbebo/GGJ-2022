using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polarity : MonoBehaviour
{
    public static Polarity playerPolarity;

    [SerializeField] public bool samePolaraityAsPlayer = true;
    public event Action<int> OnPolarityChanged;

    private int currentPolarity = PolarityStates.WHITE;

    private void Awake()
    {
        if(gameObject.tag == "Player")
        {
            setPolarity(PolarityStates.BLACK);
            playerPolarity = this;
            samePolaraityAsPlayer = true;
        }
    }

    private void Start()
    {

        if(samePolaraityAsPlayer)
        {
            setPolarity(playerPolarity.getPolarity());
        }
        else
        {
            setPolarity(playerPolarity.getPolarity() == PolarityStates.WHITE ? PolarityStates.BLACK : PolarityStates.WHITE);
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
