using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepFish : MonoBehaviour {

    public GameObject player;
    public Rigidbody2D rb2D;
    public Vector2 knockback;

    public Transform target;
    public float speed = 5f;
    public float timer;
    public float rotateSpeed = 200f;
    public int waitingTime;
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




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        startPos = transform.position;
    }

    void FixedUpdate()
    {
        playerNear = Physics2D.OverlapBox(playerCheck.position, playerCheckSize, 0f, whatIsPlayer);
        inWater = Physics2D.OverlapCircle(waterCheck.position, waterCheckRadius, whatIsWater);
        Vector3 currentpos = transform.position;
        timer += Time.deltaTime;

        
        
        float timerTimer = 2f;
        if (timerTimer < timer)
        {
            timer = 0;
        }

        if (playerNear && inWater && timer > waitingTime)
        {
            Vector3 direction = target.position - currentpos;
            direction.Normalize();
            float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 180);
            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            
            rb.velocity = direction * speed;
            
        }else if (playerNear && inWater)
        {
            Vector3 direction = target.position - currentpos;
            direction.Normalize();
            float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 180);
            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;


        }
        else
        {
            rb.transform.position = Vector3.MoveTowards(currentpos, startPos, .1f);
            transform.rotation = Quaternion.identity;
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Knockback(other));
        }
    }

    IEnumerator Knockback(Collider2D player)
    {
        Debug.Log("player collided");

        player.GetComponent<PlayerController>().enabled = false;
       

        rb2D.MovePosition(rb2D.position - knockback * Time.deltaTime);
        rb2D.velocity = new Vector2(5f, 5f);

        yield return new WaitForSeconds(1f);


        player.GetComponent<PlayerController>().enabled = true;

    }

}
