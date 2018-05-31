using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class IceBossLevelCont : MonoBehaviour {



    public PlayerController playerMovement;
    public GameObject player;
    public Bossmon bossMovement;
    public GameObject icicleWand;
    public GameObject swordfish;
    public Iceblock iceCrack;
    public DialogueManager dMan;
    public DialogueHolder SwordFishDialogue;
    public int currentLine;
   
	// Use this for initialization
	void Start () {
        
        StartCoroutine(Dialogue());
        StartCoroutine(LevelScript());
        StartCoroutine(PlayerControls());
       
	}

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && dMan.dialogActive == true)
        {
            currentLine++;
        }
    }

    IEnumerator PlayerControls()
    {
        playerMovement.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        yield return new WaitForSeconds(8.5f);
        player.GetComponent<Rigidbody2D>().isKinematic = false;
        playerMovement.GetComponent<PlayerController>().enabled = true;


    }
    IEnumerator LevelScript()
    {

        yield return new WaitForSeconds(4f);
        
        bossMovement.GetComponent<Bossmon>().enabled = true;
        //Play();
        

    }

    IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(1f);
        while (currentLine <= SwordFishDialogue.dialogueLines.Length - 1)
        {
            
            
            ShowDialogue();

            yield return new WaitForSeconds(2);
            

        }
        dMan.dialogActive = false;
        Debug.Log("continue");

        yield return StartCoroutine(LevelScript());
    }

    public void Play()
    {
        gameObject.GetComponent<PlayableDirector>().Play();
    }


    void ShowDialogue()
    {
        Debug.Log("showing1");
        dMan.dText.text = SwordFishDialogue.dialogueLines[currentLine];
        dMan.dialogLines = swordfish.GetComponent<DialogueHolder>().dialogueLines;
        dMan.currentLine = 0;
        dMan.ShowDialogue();
        


    }






}
