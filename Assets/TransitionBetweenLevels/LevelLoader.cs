using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator myTransition;
    public float loadingTime;

    [SerializeField] Exit weReachedExitScript;
    [SerializeField] GameObject pressE_txt;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && weReachedExitScript.weReachedExit) // bool ra teszem.
        {

            pressE_txt.SetActive(false);
            LoadNextLevel();
           

        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadMyLevel(  SceneManager.GetActiveScene().buildIndex +1));
          
       

    }


    IEnumerator LoadMyLevel(int levelIndex)
    {

        myTransition.SetTrigger("Finished");

        yield return new WaitForSeconds(loadingTime);


        SceneManager.LoadScene(levelIndex);
    }

    
}
