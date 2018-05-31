using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour {

    public PlayerUI playerWet;
    public PlayerController playercont;


    private void Update()
    {
        
    }

    public void wetSlider(float slider)
    {
        float currentWetness = playerWet.GetComponent<PlayerUI>().wetness;

        if (playercont.GetComponent<PlayerController>().inWater == false)
        {
            slider = currentWetness;
        }
    }
}
