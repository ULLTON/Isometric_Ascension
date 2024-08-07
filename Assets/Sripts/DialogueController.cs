using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] private GameObject player;
    private float currentHeight;
    private float highestHeight;
    string user = (System.Environment.UserName);

    // Update is called once per frame
    void Update()
    {
        currentHeight = Mathf.Round(player.transform.position.y * 100f) / 100f;

        if (currentHeight > highestHeight) highestHeight = currentHeight;

        if (highestHeight <= 1)
        {
            SetText("Rise and shine, " + user + ", it's time to keep ascending! Hehe. Time. Y-y'see, it's funny because i'm a clock. Ok bye.");
        }
        
        else
        {
            SetText("");
        }
    }

    void SetText(string textcontent)
    {
        text.text = textcontent;
    }
}
