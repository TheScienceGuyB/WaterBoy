using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour {

    public float duration;
    //public float multiplier;
    public GameObject pickupEffect;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           StartCoroutine (Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        //to do a pick up effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //Rigidbody2D playerbod = player.GetComponent<Rigidbody2D>();
        //playerbod.velocity = new Vector3(playerbod.velocity.x, Mathf.Abs(playerbod.velocity.y * multiplier), 0f);
        Rigidbody2D playerGrav = player.GetComponent<Rigidbody2D>();
        playerGrav.gravityScale = 0f;

        yield return new WaitForSeconds(duration);

       // playerbod.velocity = new Vector3(playerbod.velocity.x, Mathf.Abs(playerbod.velocity.y / multiplier), 0f);

        playerGrav.gravityScale = 1f;


        
    }
    

}
