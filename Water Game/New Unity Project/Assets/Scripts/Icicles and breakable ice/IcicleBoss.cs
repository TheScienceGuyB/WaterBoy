using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleBoss : MonoBehaviour {

    public Vector2 playerCheckSize;
    //public GameObject player;
    public Vector2 spawnPos;
    public Transform playerCheck;
    public bool playerNear;
    public LayerMask whatIsPlayer;
    public float duration;
    public float spawnDuration = 2f;
    public bool collision;

    public float moveSpeed;
    private Rigidbody2D icicleRigidBody;
    private Animator icicleAnimator;
    private Collider2D icicleCollider;
    private SpriteRenderer icicleSprite;
    public GameObject Icicle;






    void Start()
    {
        icicleRigidBody = GetComponent<Rigidbody2D>();
        icicleAnimator = GetComponent<Animator>();
        icicleCollider = GetComponent<Collider2D>();
        icicleSprite = GetComponent<SpriteRenderer>();
        spawnPos = transform.position;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerNear = Physics2D.OverlapBox(playerCheck.position, playerCheckSize, 0f, whatIsPlayer);

        if (playerNear)
        {
 
            icicleRigidBody.velocity = new Vector2(0f, -moveSpeed * Time.deltaTime);
        }



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
        
        if (other.tag == "Player")
        {
            Debug.Log("player");

          
            icicleAnimator.SetTrigger("CollisionTigger");
            StartCoroutine(IceBreak(other));
           
        }

        if (other.tag == "Bossmon")
        {

            icicleAnimator.SetTrigger("CollisionTigger");
            StartCoroutine(IceBreak(other));
        }
        if (other.tag == "KillPlane")
        {
            icicleAnimator.SetTrigger("CollisionTigger");
            StartCoroutine(IceBreak(other));

            
        }
    }






  


    IEnumerator IceBreak(Collider2D player)
    {
        yield return new WaitForSeconds(duration); //+ icicleAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);

        Object.Instantiate(Icicle, spawnPos, Quaternion.identity);
        Destroy(gameObject);



        //icicleRigidBody.velocity = new Vector3(0, 0, 0);


        //Icicle.SetActive(false);
        //isInactive = true;
        //Destroy(gameObject);
    }
    
}
