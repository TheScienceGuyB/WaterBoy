using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;
    public float followAhead;
    
    public float cameraLerpTime;
    public PlayerController playerMovement;

    private Vector3 targetPosition;
    void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = target.transform.position;
    }
}
