
using UnityEngine;

public class PuzzleDoorOpen : MonoBehaviour
{


    public bool itCanOpen;
    public Animator doorOpen;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && itCanOpen)
        {

            doorOpen.SetTrigger("OpenDoor");
                

        
        }

    }

}
