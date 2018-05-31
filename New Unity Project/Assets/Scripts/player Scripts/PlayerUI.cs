using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour {




    public float wetness = 100f;
    public Slider wetmeter;
    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    public bool hasCoin1;
    public bool hasCoin2;
    public bool hasCoin3;
    
    public PlayerController playercont;


	void Start () {
        

        wetmeter.value = 50f;

        wetness = 100f;
	}
	
	// Update is called once per frame
	void Update () {
        wetmeter.value = wetness;
        if (playercont.GetComponent<PlayerController>().inWater == false)
        {
            wetness -= 3 * Time.deltaTime;
        }
        else
        {
            wetness = 100f;

        }

        

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Pearl")
        {
            hasCoin1 = true;
            Destroy(coin1);
        }
        if (other.tag == "Pearl2")
        {
            hasCoin2 = true;
            Destroy(coin2);
        }
        if (other.tag == "Pearl3")
        {
            hasCoin3 = true;
            Destroy(coin3);
        }

    }

}
