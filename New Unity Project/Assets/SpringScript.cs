using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour {


    public Sprite springWound;
    public Sprite springUnwond;
    private SpriteRenderer spriteRenderer;
    public GameObject player;



    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("playerHit");
            StartCoroutine(Spring());
        }
    }

    IEnumerator Spring()
    {
        spriteRenderer.sprite = springUnwond;
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 3000));
        //player.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(1f);

        spriteRenderer.sprite = springWound;
        //player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));
    }
}
