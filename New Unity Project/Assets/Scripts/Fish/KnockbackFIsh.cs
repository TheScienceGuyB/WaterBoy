using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackFIsh : MonoBehaviour {


    public GameObject player;
    public Rigidbody2D rb2D;
    public Vector3 knockback;
    public float speed;
    public float vspeed;
    public float duration = 1f;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("BITCH");
            StartCoroutine(Knockback(other));
        }
    }

    IEnumerator Knockback (Collider2D player)
    {
        Debug.Log("player collided");
       
        player.GetComponent<PlayerController>().enabled = false;
        rb2D.velocity = new Vector2(0f, 0f);
        Vector3 currentpos = player.GetComponent<Rigidbody2D>().transform.position;
        

        //rb2D.transform.position = Vector3.MoveTowards(currentpos, currentpos - knockback, speed);
        rb2D.velocity = new Vector2(speed, vspeed);
        //rb2D.MovePosition(rb2D.position - knockback);

        yield return new WaitForSeconds(duration);

        player.GetComponent<PlayerController>().enabled = true;

    }





}
