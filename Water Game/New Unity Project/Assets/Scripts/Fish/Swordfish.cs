using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordfish : MonoBehaviour {

    public Transform target;
    public float speed = 5f;
    public Transform playerCheck;
    public bool playerNear;
    public LayerMask whatIsPlayer;
    public Vector2 playerCheckSize;
    private Rigidbody2D rb;
    private Vector3 startPos;

    




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
 
        startPos = transform.position;
       

    }

    void FixedUpdate()
    {
        playerNear = Physics2D.OverlapBox(playerCheck.position, playerCheckSize, 0f, whatIsPlayer);
        
        Vector3 currentpos = transform.position;


        if (playerNear)
        {

            rb.velocity = new Vector2(0, speed);
            rb.transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, 0f, 3.5f));
        }
        else if (!playerNear)
        {
            rb.velocity = new Vector2(0, 0);
            rb.transform.position = Vector3.MoveTowards(currentpos, startPos, .1f);

            
        }


    }
}
