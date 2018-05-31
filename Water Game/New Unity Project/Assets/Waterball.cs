using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterball : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(waterball());
	}
	
	IEnumerator waterball()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
