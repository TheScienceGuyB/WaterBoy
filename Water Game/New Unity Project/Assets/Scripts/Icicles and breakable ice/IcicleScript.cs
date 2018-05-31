using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleScript : MonoBehaviour {

    // Use this for initialization


    public Vector2 playerCheckSize;
    //public GameObject player;
    public Vector2 spawnPos;
    public Transform playerCheck;
    public bool playerNear;
    public LayerMask whatIsPlayer;
    public float duration;
    public float spawnDuration = 2f;
    public bool isInactive;

    public float moveSpeed;
    private Rigidbody2D icicleRigidBody;
    private Animator icicleAnimator;
    private Collider2D icicleCollider;
    private SpriteRenderer icicleSprite;
    public GameObject Icicle;






    void Start() {
        icicleRigidBody = GetComponent<Rigidbody2D>();
        icicleAnimator = GetComponent<Animator>();
        icicleCollider = GetComponent<Collider2D>();
        icicleSprite = GetComponent<SpriteRenderer>();
        spawnPos = transform.position;
        
        
    }

    // Update is called once per frame
    void FixedUpdate() {
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
            Debug.Log("player hit");
            StartCoroutine(IceBreak(other));
            //Destroy(gameObject);
        }
        if (other.tag == "Bossmon")
        {
            icicleAnimator.Play("Ice Break");
            
            
            
            
            //StartCoroutine(IceBreak(other));
        }
        //if(other.tag == "KillPlane")
        //{
        //    Object.Instantiate(Icicle, spawnPos, Quaternion.identity);
        //    Destroy(gameObject);
       // }
    }

    




    IEnumerator IceBreak (Collider2D player)
    {
        icicleAnimator.Play("Ice Break");
        
        
        

        yield return new WaitForSeconds(duration); //+ icicleAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);

        Destroy(gameObject);
            
       // Object.Instantiate(Icicle, spawnPos, Quaternion.identity);
        
        
        //icicleRigidBody.velocity = new Vector3(0, 0, 0);
        

        //Icicle.SetActive(false);
        //isInactive = true;
        //Destroy(gameObject);
    }


}
