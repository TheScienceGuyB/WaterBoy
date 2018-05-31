using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {

    public Transform playerCheck;
    public LayerMask whatIsPlayer;
    public Vector2 playerCheckSize;
    public Animator myAnim;
    public bool playerNear;

    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {

        playerNear = Physics2D.OverlapBox(playerCheck.position, playerCheckSize, 0f, whatIsPlayer);
        if (playerNear == true)
        {
            myAnim.SetBool("playerClose", true);
        }
	}
}
