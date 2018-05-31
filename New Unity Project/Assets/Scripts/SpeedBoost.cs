using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {

    public PlayerController playercont;
    public float boostSpeed;
    public float returnSpeed;
   
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Booster());
        }
    }

    IEnumerator Booster()
    {
        playercont.moveSpeed = playercont.moveSpeed = boostSpeed;

        yield return new WaitForSeconds(2f);

        playercont.moveSpeed = playercont.moveSpeed = returnSpeed;

    }
}
