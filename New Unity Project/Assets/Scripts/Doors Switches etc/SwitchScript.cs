using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

    public Sprite switchOff;
    public Sprite switchOn;
    public GameObject door;
    public bool switchIsOn;
    private SpriteRenderer switchSprite;



	void Start () {
        switchSprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            switchSprite.sprite = switchOn;
            Destroy(door.gameObject);
            switchIsOn = true;
        }
    }

}
