using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
    public class BballGameScript : MonoBehaviour
    {
        public GameObject swordFishBoy;
        public Transform playerpos;
        
        public GameObject formation1;
        public GameObject formation2;
        public GameObject formation3;
        public GameObject formation4;
        public GameObject player;
        public DialogueHolder swordFishDialogue;
        public DialogueManager dMan;
        public PlayerController playerMove;
        private Rigidbody2D body;
        public int e;
        public int n;
        public int currentline;
   
        

       

        void Start()
        {
            body = dMan.body;
            
            ShowDialogue();
        }

        // Update is called once per frame
        void Update()
        {
            if (dMan.dialogActive == false)
            {
                player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            
            
            //playerMove.GetComponent<PlayerController>().enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                    e++;
            }    


            if (e == 4)
            {
                
                StartCoroutine(FormationSpawner());
                
                
            }
            if (e <= 5)
            {
                playerMove.GetComponent<PlayerController>().enabled = false;
            }

            if (n == 1)
            {
                StartCoroutine(Formation2());
            }
            if (n == 3)
            {
                StartCoroutine(Formation3());
                
            }
            if (n == 5)
            {
                StartCoroutine(Formation4());
            }


        }

        IEnumerator FormationSpawner()
        {
            var shakePreset = ProCamera2DShake.Instance.ShakePresets[Random.Range(0, ProCamera2DShake.Instance.ShakePresets.Count)];


            ProCamera2DShake.Instance.Shake(shakePreset);


            yield return new WaitForSeconds(1);
            formation1.SetActive(true);
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            

        }

        IEnumerator Formation2()
        {

            while (player.transform.position.x != playerpos.transform.position.x)
            {
                player.transform.position = new Vector2(playerpos.transform.position.x, playerpos.transform.position.y);
                yield return null;

            }

            ShowDialogue2();
            


            var shakePreset = ProCamera2DShake.Instance.ShakePresets[Random.Range(0, ProCamera2DShake.Instance.ShakePresets.Count)];
            ProCamera2DShake.Instance.Shake(shakePreset);
            yield return new WaitForSeconds(2f);  
            ProCamera2DShake.Instance.StopShaking();
            formation1.SetActive(false);
            yield return new WaitForSeconds(1f);
            formation2.SetActive(true);
            n = 2;
            StopCoroutine(Formation2());
            //StopDialogue2();

        }
        IEnumerator Formation3()
        {
            while (player.transform.position.x != playerpos.transform.position.x)
            {
                player.transform.position = new Vector2(playerpos.transform.position.x, playerpos.transform.position.y);
                yield return null;

            }
            ShowDialogue3();
           
            
            var shakePreset = ProCamera2DShake.Instance.ShakePresets[Random.Range(0, ProCamera2DShake.Instance.ShakePresets.Count)];
            ProCamera2DShake.Instance.Shake(shakePreset);
            
            yield return new WaitForSeconds(2f);
          
            ProCamera2DShake.Instance.StopShaking();
            formation2.SetActive(false);
            yield return new WaitForSeconds(1f);
          
            formation3.SetActive(true);
            n=4;
            StopCoroutine(Formation3());
          


        }

        IEnumerator Formation4()
        {
            while (player.transform.position.x != playerpos.transform.position.x)
            {
                player.transform.position = new Vector2(playerpos.transform.position.x, playerpos.transform.position.y);
                yield return null;

            }
    
            var shakePreset = ProCamera2DShake.Instance.ShakePresets[Random.Range(0, ProCamera2DShake.Instance.ShakePresets.Count)];
            ProCamera2DShake.Instance.Shake(shakePreset);
            yield return new WaitForSeconds(2f);
            ProCamera2DShake.Instance.StopShaking();
            formation3.SetActive(false);
            Destroy(swordFishBoy);
            yield return new WaitForSeconds(1f);
            formation4.SetActive(true);
            n = 6;
           
  
        }




        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {

                n++;
            }
        }

        void ShowDialogue()
        {
            dMan.dialogLines = swordFishDialogue.dialogueLines;
            dMan.currentLine = 0;
            dMan.ShowDialogue();
            dMan.dText.text = swordFishDialogue.dialogueLines[dMan.currentLine];
        }
        void ShowDialogue2()
        {
            dMan.dialogLines = swordFishBoy.GetComponent<DialogueHolder>().dialogueLines1;
            dMan.currentLine = 0;
            dMan.ShowDialogue();
            dMan.dText.text = swordFishDialogue.dialogueLines1[currentline];
        }
        /*
        void StopDialogue2()
        {
            dMan.dialogActive = false;
            dMan.dBox.SetActive(false);
            player.GetComponent<PlayerController>().enabled = true;
            player.GetComponent<PlayerUI>().enabled = true;
            body.bodyType = RigidbodyType2D.Dynamic;
        }
        */
        void ShowDialogue3()
        {
            dMan.dialogLines = swordFishDialogue.dialogueLines2;
            dMan.currentLine = 0;
            dMan.ShowDialogue();
            dMan.dText.text = swordFishDialogue.dialogueLines2[currentline];
           
        }


    }


    


}


