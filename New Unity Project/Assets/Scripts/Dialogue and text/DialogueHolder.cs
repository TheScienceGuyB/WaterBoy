using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    public string dialogue;
    private DialogueManager dMan;
    public string[] dialogueLines;
    public string[] dialogueLines1;
    public string[] dialogueLines2;
	void Start () {
        dMan = FindObjectOfType<DialogueManager>();


        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            
            if (Input.GetKeyUp(KeyCode.E))
            {
                
                //dMan.ShowBox(dialogue);

                if (dMan.dialogActive == false)
                {
                    
                    dMan.dialogLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                }
            }
        }
    }

     public void StartTalking()
     {
        
        dMan.dialogActive = true;
        dMan.dBox.SetActive(true);
        if (Input.GetKeyUp(KeyCode.E))
        {

            
            dMan.dialogLines = dMan.dialogLines1;
            //dMan.currentLine = 0;
            dMan.ShowDialogue();
            dMan.currentLine1++;
        
            
            
        }
     }
} 
