using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle: MonoBehaviour
{



    [SerializeField] PuzzleDoorOpen openTheDoor;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rocket")) 
        {

            openTheDoor.itCanOpen = true;
            

        }


    }

}
