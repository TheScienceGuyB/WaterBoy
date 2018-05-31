using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeCame : MonoBehaviour {

    public GameObject target;
    public float followAhead;

    public float cameraLerpTime;
    public PlayerController playerMovement;

    private Vector3 targetPosition;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

        // this moves camera ahead of player
        /* if (target.transform.localScale.x >= 0f)
         {
             targetPosition = new Vector3(targetPosition.x + followAhead, Mathf.Clamp(targetPosition.y, -100, 2), targetPosition.z);
         }
         else
         {
             targetPosition = new Vector3(targetPosition.x - followAhead, Mathf.Clamp(targetPosition.y, -100, 2), targetPosition.z);
         }


         //transform.position = targetPosition;
         */
        transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z); //Vector3.Lerp(transform.position, targetPosition, cameraLerpTime * Time.deltaTime);
    
    }

}
