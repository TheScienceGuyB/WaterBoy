using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunActivation : MonoBehaviour {

    public PlayerController playerMove;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerMove.waterGun = true;
            
        }
    }
}
