
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ind_PauseMaker : MonoBehaviour
{

    [SerializeField] GameObject pausePanel;
    public static bool pause = false;




    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {

            if (pause)
            {
                ResumeTheGame();

            }
            else 
            {
                PauseTheGame();
                      
            }

        }





    }



    public void ResumeTheGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
        Debug.Log("The game is going on,");


        Cursor.lockState = CursorLockMode.Locked;

    }

    private void PauseTheGame()
    {

        pausePanel.SetActive(true);
        pause = true;
        Time.timeScale = 0f;


        Cursor.lockState = CursorLockMode.Confined;

        Debug.Log("The game is paused and the time stopped as well");
    }

    public void BackToTheMainMenu()
    {

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }

    public void Qut()
    {

        Application.Quit();
        Debug.Log("quit");
    
    }


}
