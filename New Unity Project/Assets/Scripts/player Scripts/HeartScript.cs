using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour {


    public PlayerInteractibles healthPoints;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            healthPoints.health += Mathf.Clamp(50,0,200);
            Destroy(gameObject);
        }
    }
}
