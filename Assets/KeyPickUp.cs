
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    [SerializeField] GameObject playerCam;

    public bool red;
    public bool yellow;
    public bool blue;


    private void Update()
    {
        transform.rotation = playerCam.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {


            if (red)
            {
                other.GetComponent<PlayerPocket>().weHaveRedKey = true;
                ScreenDataManager.instanceHandler.KeysReport("red");

                
            
            }
            if (yellow)
            {
                other.GetComponent<PlayerPocket>().weHaveYellowKey = true;
                ScreenDataManager.instanceHandler.KeysReport("yellow");

                
            }
            if (blue)
            {
                other.GetComponent<PlayerPocket>().weHaveBlueKey = true;
                ScreenDataManager.instanceHandler.KeysReport("blue"); 
                

            }

                  Destroy(gameObject);

        }


    }
}
