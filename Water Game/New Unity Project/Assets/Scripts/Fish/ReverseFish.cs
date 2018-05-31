using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class ReverseFish : MonoBehaviour {

    public Transform target;
    public float speed = 5f;
    public float rotateSpeed = 200f;
    public Transform playerCheck;
    public bool playerNear;
    public LayerMask whatIsPlayer;
    public Vector2 playerCheckSize;
    private Rigidbody2D rb;
    public LayerMask whatIsWater;
    public Transform waterCheck;
    public float waterCheckRadius;
    private Vector3 startPos;

    public bool inWater;




    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        startPos = transform.position;

    }

    void FixedUpdate()
    {
        playerNear = Physics2D.OverlapBox(playerCheck.position, playerCheckSize, 0f, whatIsPlayer);
        inWater = Physics2D.OverlapCircle(waterCheck.position, waterCheckRadius, whatIsWater);
        Vector3 currentpos = transform.position;


        if (playerNear && inWater) {

            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.right).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.velocity = transform.right * speed;

        }
        else
        {
            rb.transform.position = Vector3.MoveTowards(currentpos, startPos, .1f);
            
            //rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
       
       
    }


}
