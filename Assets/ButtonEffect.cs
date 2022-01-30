using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEffect : MonoBehaviour
{

    public void ZoomIn()
    {
        gameObject.transform.localScale = new Vector2(1.02f, 1.02f);
    }

    public void ZoomOut()
    {
        gameObject.transform.localScale = new Vector2(1f, 1f);
    }
}
