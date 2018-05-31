using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteManager : MonoBehaviour {

    public PlayerController playerMove;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerMove.waterGun == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
	}
}
