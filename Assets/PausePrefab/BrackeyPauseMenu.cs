using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrackeyPauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI_brackeyPauseMenu_pnl;



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {

            if (GameIsPaused)
            {

                Resume();
            }
            else
            {
                PauseTheGame();
            }



        }


        Debug.Log(Time.time); 

    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;

        pauseMenuUI_brackeyPauseMenu_pnl.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;

    }

    void PauseTheGame()
    {
        Cursor.lockState = CursorLockMode.Confined;

        pauseMenuUI_brackeyPauseMenu_pnl.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void LoadMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;


        Debug.Log("load menu");
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void QuitGame()
     {

        Debug.Log("Quit");
        Application.Quit();

    }


}
