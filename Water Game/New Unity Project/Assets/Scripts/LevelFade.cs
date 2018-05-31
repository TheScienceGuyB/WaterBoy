
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFade : MonoBehaviour {


    public Animator animator;
    public string LevelToLoad;
    public string levelname;


	// Update is called once per frame
	void Update () {
        
	}

    public void FadeToLevel(string name)
    {
        LevelToLoad = name;
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FadeToLevel(levelname);
    }


}
