using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PearlUI1 : MonoBehaviour {


    public PlayerUI playerPearls;
    public GameObject pearlImage;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerPearls.hasCoin2 == true)
        {

            pearlImage.GetComponent<Image>().enabled = true;
        }


    }
}
