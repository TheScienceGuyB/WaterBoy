using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwordFishTransition : MonoBehaviour {

    public EndFlag endFlag;

    public DialogueManager dMan;
    public int currentLine = 0;
    public string nextLevel;

	void Start () {
        gameObject.GetComponent<SwordFishTransition>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.E))
        {
            currentLine++;
        }
		if (currentLine >= 2)
        {
            SceneManager.LoadScene(nextLevel);
            dMan.dBox.SetActive(false);
        }
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.tag == "Player")
        {
            
            gameObject.GetComponent<SwordFishTransition>().enabled = true;
            dMan.dialogLines = gameObject.GetComponent<DialogueHolder>().dialogueLines;
            dMan.currentLine = 0;
            dMan.ShowDialogue();
        }
    }

    


}
