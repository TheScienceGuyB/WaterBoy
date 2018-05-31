using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    [RequireComponent(typeof(Collider2D))]
    public class TransitionPoint : MonoBehaviour
    {

    public GameObject doorDestination;



        public enum TransitionType
        {
            DifferentZone, DifferentNonGameplayScene, SameScene,
        }


        public enum TransitionWhen
        {
            ExternalCall, InteractPressed, OnTriggerEnter,
        }


        [Tooltip("This is the gameobject that will transition.  For example, the player.")]
        public GameObject transitioningGameObject;
        [Tooltip("Whether the transition will be within this scene, to a different zone or a non-gameplay scene.")]
        public TransitionType transitionType;
   
        [Tooltip("The destination in this scene that the transitioning gameobject will be teleported.")]
        public TransitionPoint destinationTransform;
        [Tooltip("What should trigger the transition to start.")]
        public TransitionWhen transitionWhen;
        [Tooltip("The player will lose control when the transition happens but should the axis and button values reset to the default when control is lost.")]
        public bool resetInputValuesOnTransition = true;
        [Tooltip("Is this transition only possible with specific items in the inventory?")]
        public bool requiresInventoryCheck;
        [Tooltip("The inventory to be checked.")]
  

        bool m_TransitioningGameObjectPresent;

        void Start()
        {
            if (transitionWhen == TransitionWhen.ExternalCall)
                m_TransitioningGameObjectPresent = true;
        }

    /* void OnTriggerEnter2D(Collider2D other)
     {
         if (other.gameObject == transitioningGameObject)
         {
             m_TransitioningGameObjectPresent = true;



             if (transitionWhen == TransitionWhen.OnTriggerEnter)
                 TransitionInternal();
         }
     }

     void OnTriggerExit2D(Collider2D other)
     {
         if (other.gameObject == transitioningGameObject)
         {
             m_TransitioningGameObjectPresent = false;
         }
     }

 */
    private void OnTriggerStay2D(Collider2D other)

    {
        if (other.tag == "Player" && Input.GetButtonDown("Interact"))
        {
            
            
          GameObjectTeleporter.Teleport(transitioningGameObject, destinationTransform.transform);

           Debug.Log("interacted");
            
         Debug.Log("stay" + other.tag);
        }
    }

    void Update()
        {
       

            if (!m_TransitioningGameObjectPresent)
                return;

            if (transitionWhen == TransitionWhen.InteractPressed)
            {
                if (transitionType == TransitionType.SameScene)
                {
                
                GameObjectTeleporter.Teleport(transitioningGameObject, destinationTransform.transform);

                
                }
        
            }
             
            
        }

        protected void TransitionInternal()
        {
        

            if (transitionType == TransitionType.SameScene)
            {
                
                GameObjectTeleporter.Teleport(transitioningGameObject, destinationTransform.transform);
            }
        }

        public void Transition()
        {
            if (!m_TransitioningGameObjectPresent)
                return;

            if (transitionWhen == TransitionWhen.ExternalCall)
                TransitionInternal();
        }
    }
