using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnim;

    public bool keyRequired;
    public bool red;
    public bool blue;
    public bool yellow;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            

            if (keyRequired)
            {
                if (red && other.GetComponent<PlayerPocket>().weHaveRedKey)
                {
                    doorAnim.SetTrigger("OpenDoor");
                }
                if (blue && other.GetComponent<PlayerPocket>().weHaveBlueKey)
                {
                    doorAnim.SetTrigger("OpenDoor");
                }
                if (yellow && other.GetComponent<PlayerPocket>().weHaveYellowKey)
                {
                    doorAnim.SetTrigger("OpenDoor");
                }

            }
            else { doorAnim.SetTrigger("OpenDoor");}



        }

    }
}
