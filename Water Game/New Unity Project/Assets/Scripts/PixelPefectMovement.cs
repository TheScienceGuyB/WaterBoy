using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPefectMovement : MonoBehaviour {


    Vector2 position;
    
	void Update () {
        
	}
    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), -10f);
    }
}
