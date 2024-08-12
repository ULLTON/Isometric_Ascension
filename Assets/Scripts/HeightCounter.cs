using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeightCounter : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] TMP_Text counter;
    private float Height;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        Height = Mathf.Round(player.transform.position.y*100f)/100f;
        counter.text = "Height: " + Height;
    }
}
