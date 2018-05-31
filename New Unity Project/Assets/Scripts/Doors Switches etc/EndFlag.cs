using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour {
    public Sprite flagClosed;
    public Sprite flagOpen;
    public string nextLevel;

    private SpriteRenderer spriteRenderer;

    public bool checkpointActive;
    
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(loadLevel(other));
        }
    }

    IEnumerator loadLevel (Collider2D player)
    {
        spriteRenderer.sprite = flagOpen;
        checkpointActive = true;

        yield return new WaitForSeconds(2);

        Scene next = SceneManager.GetSceneByName(nextLevel);
        SceneManager.LoadScene(nextLevel);

    }


}
