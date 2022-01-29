using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Polarity))]
public class LayerSwitcher : MonoBehaviour
{
    public static readonly int WhiteLayer = 6;
    public static readonly int BlackLayer = 7;

    private Polarity polarity;
    // Start is called before the first frame update
    void Start()
    {
        polarity = GetComponent<Polarity>();
        polarity.OnPolarityChanged += OnPolarityChange;
        OnPolarityChange(polarity.getPolarity());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPolarityChange(int polarity)
    {
        if(polarity == PolarityStates.WHITE)
        {
            gameObject.layer = WhiteLayer;
        }
        else
        {
            gameObject.layer = BlackLayer;
        }
    }
}
