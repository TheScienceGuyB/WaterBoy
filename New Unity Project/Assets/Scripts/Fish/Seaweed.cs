using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seaweed : MonoBehaviour {


    public PlayerController playermovement;
    public bool slowMovement;
    public float normalPlayerMovespeed;
    public float normalPlayerVMovespeed;



    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            slowMovement = true;

            StartCoroutine(MoveSlow());
 
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            slowMovement = false;
        }
    }

    IEnumerator MoveSlow()
    {
        while (slowMovement == true)
        {
            playermovement.moveSpeed = 80f;
            playermovement.vMoveSpeed = 80f;
            playermovement.jumpSpeed = 0f;
            
            yield return null;
        }
           
            yield return new WaitForSeconds(1f);


        playermovement.jumpSpeed = 7f;
            playermovement.moveSpeed = 375f;
            playermovement.vMoveSpeed = 375f;
        

        
    }

}
