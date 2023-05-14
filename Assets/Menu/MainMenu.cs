using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void StartGame()
    {

        SceneManager.LoadScene(1); // egyes index� scene bet�lt�dik
      //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }

    public void QuitGame()
    {

        Debug.Log("Quit 1");
        Application.Quit();
        Debug.Log("Quit 2");
    }


    public void BackToMenu()
    {

        SceneManager.LoadScene(0); 
      
    }


}
