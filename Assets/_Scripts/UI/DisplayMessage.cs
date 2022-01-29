using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMessage : MonoBehaviour
{
    private static DisplayMessage instance;
    private static Queue<string> messages = new Queue<string>();
    private static float timer;
    private static float duration;
    private static TextMeshProUGUI text; 


    public TextMeshProUGUI displayText;
    public float displayDuration;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        text = displayText;
        duration = displayDuration;
        timer = duration;

        if (text == null || text.Equals(null))
        {
            Debug.LogError("DisplayMessage component needs a TMPro.TextMeshProUGUI element", this);
            gameObject.SetActive(false);
        }



    }

    private void Update()
    {
        if(timer < 0)
        {
            string newMsg;
            if (messages.Count > 0)
                newMsg = messages.Dequeue();
            else
                newMsg = string.Empty;

            text.text = newMsg;
            timer = duration;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public static void NewMessage(string message)
    {
        messages.Enqueue(message);

        if(messages.Count > 25)
            Debug.LogWarning($"There are {messages.Count} messages lined up in the queue.");

        // if there is only one messeage in the queue display it.
        // Otherwise, wait for the timer to display it.
        if(messages.Count == 1)
        {
            text.text = messages.Dequeue();
            timer = duration;
        }
    }

    public static void SetNewDisplayDuration(float newDuration)
    {
        if(newDuration > 0f)
            duration = newDuration;
        else
            Debug.LogError("New duration must be greater than 0");

    }
}
