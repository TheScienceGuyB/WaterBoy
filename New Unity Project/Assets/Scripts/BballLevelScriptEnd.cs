using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Com.LuisPedroFonseca.ProCamera2D
{





    public class BballLevelScriptEnd : MonoBehaviour
    {

        public GameObject blackPanel;
        public GameObject player;
        public GameObject swordfish;
        public GameObject iceBreak;
        public DialogueHolder SwordFishDialogue1;
        public DialogueManager dMan;
        public Animator pedastal;
        public int currentLine;
        public int i;
       


        // Use this for initialization
        void Start()
        {
            gameObject.GetComponent<BballLevelScriptEnd>().enabled = (false);
        }

        // Update is called once per frame
        void Update()
        {
            player.GetComponent<PlayerUI>().enabled = false;
            if (Input.GetKeyDown(KeyCode.E) && dMan.dialogActive == true) 
            {
                currentLine++;
            }
    
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                gameObject.GetComponent<BballLevelScriptEnd>().enabled = (true);
                StartCoroutine(TrophyCoroutine());
            }

        }



        IEnumerator TrophyCoroutine()
        {
        
            yield return new WaitForSeconds(2f);
            

            Destroy(blackPanel);

            while (currentLine < SwordFishDialogue1.dialogueLines.Length - 1)
            {
                dMan.dialogActive = true;
                ShowDialogue();
                
                yield return new WaitForSeconds(100000000);
                
            }
            
           
            yield return StartCoroutine(TrophyFall());

            
            yield return StartCoroutine(loadScence());
       
  
        }
        IEnumerator TrophyFall()
        {
            dMan.dialogActive = false;
            dMan.dBox.SetActive(false);
            pedastal.Play("TrophyFallG");
            yield return new WaitForSeconds(4);
            
            pedastal.Play("SquishG");
            yield return new WaitForSeconds(2.5f);
            
            var shakePreset = ProCamera2DShake.Instance.ShakePresets[Random.Range(0, ProCamera2DShake.Instance.ShakePresets.Count)];
            ProCamera2DShake.Instance.Shake(shakePreset);
            yield return new WaitForSeconds(2f);

        }
        IEnumerator loadScence()
        {
            Destroy(iceBreak);
            pedastal.Play("fallingPedastalG");
            yield return null;
        }


        



        void ShowDialogue()
        {
            dMan.dialogLines = swordfish.GetComponent<DialogueHolder>().dialogueLines;
            currentLine = 0;
            dMan.ShowDialogue();
            dMan.dText.text = SwordFishDialogue1.dialogueLines[currentLine];
    

        }

       
    }






}
   
