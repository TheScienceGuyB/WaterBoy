using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectRescale : MonoBehaviour {
    public int screenVerticalPixels = 256;
    public bool preferUncropped = true;
    private float screenPixelsY = 0;
    private bool currentCropped = false;

    private void Update()
    {
        if(screenPixelsY != (float)Screen.height || currentCropped != preferUncropped)
        {
            screenPixelsY = (float)Screen.height;
            currentCropped = preferUncropped;
            float screenRatio = screenPixelsY / screenVerticalPixels;
            float ratio;
            
            if (preferUncropped)
            {
                ratio = Mathf.Floor(screenRatio) / screenRatio;
            }
            else
            {
                ratio = Mathf.Ceil(screenRatio) / screenRatio;
            }
            transform.localScale = Vector3.one * ratio;

        }
    }


}
