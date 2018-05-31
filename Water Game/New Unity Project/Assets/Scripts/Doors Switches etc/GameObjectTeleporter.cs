using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class GameObjectTeleporter : MonoBehaviour
    {


    


        public static GameObjectTeleporter Instance

        {
            get
            {
                if (instance != null)
                    return instance;

                instance = FindObjectOfType<GameObjectTeleporter>();

                if (instance != null)
                    return instance;

                GameObject gameObjectTeleporter = new GameObject("GameObjectTeleporter");
                instance = gameObjectTeleporter.AddComponent<GameObjectTeleporter>();

                return instance;
            }
        }

        public static bool Transitioning
        {
            get { return Instance.m_Transitioning; }
        }

        protected static GameObjectTeleporter instance;

        protected PlayerController m_PlayerInput;
        protected bool m_Transitioning;

        void Awake()
        {
            //if (Instance != this)
           // {
           //     Destroy(gameObject);
           //     return;
          //  }

          //  DontDestroyOnLoad(gameObject);

            m_PlayerInput = FindObjectOfType<PlayerController>();
        }

        public static void Teleport(GameObject transitioningGameObject, Transform destination)
        {
             
            transitioningGameObject.transform.position = new Vector3(destination.position.x, destination.position.y);
        Component temp = transitioningGameObject.GetComponent<Rigidbody2D>();
        //temp.rigidbody2D.transform.position.x
       
            Debug.Log("Teleporting");
        float tempx = transitioningGameObject.transform.position.x;
        float tempy = transitioningGameObject.transform.position.y;
        Debug.Log("Our position:" + tempx + tempy);
        Debug.Log("Target position:" + destination.transform.position.x + destination.transform.position.y);
        }
 
    }


