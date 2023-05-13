
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject pressE;
    public bool weReachedExit;
    bool subtitle;
   
    private void OnTriggerEnter(Collider other)
    {
 

        if (other.CompareTag("Player")  && !subtitle )
        {
            weReachedExit = true;
            pressE.SetActive(true);

           
           
        }
        else { weReachedExit = false; }

        if (Input.GetKeyDown(KeyCode.E)) // wow mûködik
        {
            subtitle = true;
            
        }

 
        if (SceneManager.sceneCount <= SceneManager.GetActiveScene().buildIndex )
        {
            Debug.Log("It was your final level");       
        }

    }

    private void OnTriggerExit(Collider other)
    {      
        if (other.CompareTag("Player") )
        {
            pressE.SetActive(false);
            weReachedExit = false; 
        }

    }
}
