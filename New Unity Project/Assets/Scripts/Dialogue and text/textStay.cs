using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textStay : MonoBehaviour {

    private TextMesh textAlpha;
    void Start()
    {
        textAlpha = GetComponent<TextMesh>();
        Color startingAlpha = textAlpha.GetComponent<TextMesh>().color;
        startingAlpha.a = 0f;
        textAlpha.GetComponent<TextMesh>().color = startingAlpha;

    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        Color text = textAlpha.GetComponent<TextMesh>().color;
        text.a = 1f;
        
        if (other.CompareTag("Player"))
        {
                textAlpha.GetComponent<TextMesh>().color = text;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Color textExit = textAlpha.GetComponent<TextMesh>().color;
        textExit.a = 0f;
        if (other.tag == "Player")
        {
            textAlpha.GetComponent<TextMesh>().color = textExit;
        }
    }
}
