using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;
    public bool dialogActive;
    public PlayerController player;
    public PlayerUI playerUI;
    public GameObject playerG;
    public Rigidbody2D body;


    public string[] dialogLines;
    public string[] dialogLines1;
    
    public int currentLine;
    public int currentLine1;
    private int reset;
	void Start () {
        body = playerG.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
        
        //else
        //{
          //  player.GetComponent<PlayerController>().enabled = true;
          //  playerUI.GetComponent<PlayerUI>().enabled = true;
          //  playerG.GetComponent<Rigidbody2D>().isKinematic = false;
          //  body.bodyType = RigidbodyType2D.Dynamic;
        //}


        if (dialogActive == true && Input.GetKeyUp(KeyCode.E))
        {
            
            //dBox.SetActive(false);
            //dialogActive = false;
            currentLine++;
        }
        if (currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;
            currentLine = 0;
            
            playerUI.GetComponent<PlayerUI>().enabled = true;
            //playerG.GetComponent<Rigidbody2D>().isKinematic = false;
            body.bodyType = RigidbodyType2D.Dynamic;
            reset = 1;
        }
        if (reset == 1)
        {
            player.GetComponent<PlayerController>().enabled = true;
            reset = 0;
        }
        dText.text = dialogLines[currentLine];
		
	}
    public void ShowBox(string dialogue)
    {
        
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }
    
   
    public void ShowDialogue()
    {
        
        player.GetComponent<PlayerController>().enabled = false;
        playerUI.GetComponent<PlayerUI>().enabled = false;
        body.bodyType = RigidbodyType2D.Static;
        dialogActive = true;
        dBox.SetActive(true);
    }
    
}
