using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceblock : MonoBehaviour {


    public GameObject iceBlock;


	// Use this for initialization
	void Start () {
       // StartCoroutine(Icebreak());
	}
	
	


    IEnumerator Icebreak()
    {
        iceBlock.GetComponent<Animator>().Play("Break");
        
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
