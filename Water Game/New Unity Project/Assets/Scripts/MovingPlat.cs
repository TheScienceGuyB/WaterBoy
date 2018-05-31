using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour {

    public Transform pos1;
    public Transform pos2;
    public float timeTillRepeat;
	void Start () {
        InvokeRepeating("StartCo", 0, timeTillRepeat);
	}
	
    
    /*
    IEnumerator MovePlat()
    {
        StartCoroutine(Move1());
        yield return null;
        
        StartCoroutine(Move2());
        yield return null;
    }
    */


    void StartCo()
    {
        StartCoroutine(Move1());
    }


    IEnumerator Move1()
    {
        while(transform.position.y != pos2.position.y) {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(pos2.position.x, pos2.position.y), 6 * Time.deltaTime);
            yield return null;
        }
        while (transform.position.y != pos1.position.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(pos1.position.x, pos1.position.y), 6 * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1);
    }

   
}
