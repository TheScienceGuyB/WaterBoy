using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceChunk : MonoBehaviour {

    public Transform playerCheck;
    public bool playerNear;
    public LayerMask whatIsPlayer;
    public Vector2 playerCheckSize;
    public bool keepMoving;
    int i;



    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        playerNear = Physics2D.OverlapBox(playerCheck.position, playerCheckSize, 0f, whatIsPlayer);
        
        if (playerNear)
        {

            i++;
        }
        if (i >= 1)
        {
            StartCoroutine(Move());
        }


    }


    IEnumerator Move()
    {
        gameObject.GetComponent<Animator>().Play("SpinningIceChunk");
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-10, 0, 0);
        
        

        yield return null;
        
    }
}
