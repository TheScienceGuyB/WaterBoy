using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {
    public PlayerController watergun;
    int i;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Interact"))
        {
            gameObject.GetComponent<Animator>().Play("WaterGunChest");
            i++;
        }
        if (Input.GetButtonDown("Interact")&& i >= 2) {
            gameObject.GetComponent<Animator>().Play("idle");
           // watergun.SetBool("water", true);

            watergun.waterGun = true;
        }
	}
}
