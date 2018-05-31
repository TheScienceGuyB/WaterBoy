using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthpointText : MonoBehaviour {

    private Text healthpointText;
    void Start()
    {
        healthpointText = GetComponent<Text>();
    }

    // Update is called once per frame
    public void textUpdate(float value)
    {
        healthpointText.text =  "" +Mathf.RoundToInt(value);
    }
}
