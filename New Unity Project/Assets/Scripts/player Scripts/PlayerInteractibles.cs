using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class PlayerInteractibles : MonoBehaviour
    {



        private Rigidbody2D myRigidBody;
        private Vector3 respawnPosition;
        private GameObject player;
        public TransitionPoint destinationTransform;

        
        public Slider healthbar;
        public PlayerUI playerWet;
        public int health = 200;
        public float decreaseSpeed;
        public float seaweedDuration;
        public PlayerController playerMovement;
        public TransitionPoint transitionPoint;










        // Use this for initialization
        void Start()
        {
            myRigidBody = GetComponent<Rigidbody2D>();
            player = GetComponent<GameObject>();


        }

        // Update is called once per frame
        void Update()
        {
            float currentWet = playerWet.wetness;
            healthbar.value = health;


            if (health <= 0 || currentWet <= 0f)
            {

                transform.position = respawnPosition;
                Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
                myRigidBody.velocity = new Vector3(0f, 0f, 0f);
                health = 200;
                playerWet.wetness = 100f;
            
            }
            if (health > 200)
            {
                health = 200;
                
            }



        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "KillPlane")
            {
                // How to Deactivate things (checkbox)
                //gameObject.SetActive(false);

                transform.position = respawnPosition;

            }
            if (other.tag == "CheckPoint")
            {
                respawnPosition = other.transform.position;
            }
            if (other.tag == "Urchin")
            {
                health -= 100;
                
            }
            if (other.tag == "Icicles")
            {
                health -= 75;
            }

            if (other.tag == "ReverseFish")
            {
                StartCoroutine(Reverse(other));
            }



        }

        IEnumerator Reverse(Collider2D player)
        {


            playerMovement.moveSpeed = -playerMovement.moveSpeed;
            playerMovement.vMoveSpeed = -playerMovement.vMoveSpeed;


            yield return new WaitForSecondsRealtime(2);
            playerMovement.moveSpeed = Mathf.Abs(playerMovement.moveSpeed);
            playerMovement.vMoveSpeed = Mathf.Abs(playerMovement.vMoveSpeed);

        }








    }

