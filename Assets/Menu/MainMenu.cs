using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {

        SceneManager.LoadScene(1); // egyes indexû scene betöltõdik
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {

        Debug.Log("Quit 1");
        Application.Quit();
        Debug.Log("Quit 2");
    }
    


}
