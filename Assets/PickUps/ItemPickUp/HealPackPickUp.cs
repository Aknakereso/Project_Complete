 
using UnityEngine;

public class HealPackPickUp : MonoBehaviour
{
   [SerializeField] GameObject playerCam;
  // [SerializeField] PlayerController playerHealth;

    [SerializeField] Player_Life playerHealth;

    public bool largeHealthPack;
    public bool mediumHealthPack;
    public bool smallHealthPack;


    private void Update()
    {      
        transform.rotation = playerCam.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            if (largeHealthPack)
            {
                playerHealth.GetHealth(20, gameObject);
            }

            if (mediumHealthPack)
            {
                playerHealth.GetHealth(15, gameObject);
            }

            if (smallHealthPack)
            {
                playerHealth.GetHealth(5, gameObject);
            }         
        }
    }


}
