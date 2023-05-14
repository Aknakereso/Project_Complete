using UnityEngine;

public class Points : MonoBehaviour
{

    [SerializeField] Player_collectStuffs playerPocket;


    [SerializeField] bool cyan;
    [SerializeField] bool red;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            //playerPocket.cyanBalls++; mûködött


            if (cyan)
            { 
             playerPocket.PickUpCyanBalls(1, gameObject);


              //Destroy(gameObject);
            
            }

            if (red)
            {
                playerPocket.PickUpRedBalls(1, gameObject);


               // Destroy(gameObject);

            }


           
        }
    }


}
