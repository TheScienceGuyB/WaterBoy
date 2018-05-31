using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretBlock : MonoBehaviour {

    private SpriteRenderer secret;
    //private float fadeTime = 2.5f;
    public float minimum = .3f;
    public float maximum = 1f;
    private float startTime;
    //private float duration = 1f;


    private void Start()
    {
        secret = GetComponent<SpriteRenderer>();
        //Color block = secret.GetComponent<SpriteRenderer>().color;
       // block.a = 255f;
    }

    

    private void OnTriggerStay2D(Collider2D other)
    {
        Color block = secret.GetComponent<SpriteRenderer>().color;
        block.a = .3f;
       
        if (other.tag == "Player")
        {

            secret.GetComponent<SpriteRenderer>().color = block;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Color blockE = secret.GetComponent<SpriteRenderer>().color;
        blockE.a = 1f;
        if(other.tag == "Player")
        {
            secret.GetComponent<SpriteRenderer>().color = blockE;
        }
    }
}
