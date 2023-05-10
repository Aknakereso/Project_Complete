
using UnityEngine;

public class ArmorPickUp : MonoBehaviour
{
    [SerializeField] GameObject playerCam;
    [SerializeField] PlayerController playerArmor;

    public bool largeArmor;
    public bool mediumArmor;
   


    private void Update()
    {
        transform.rotation = playerCam.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            if (largeArmor)
            {
                playerArmor.GetArmor(20, gameObject);
            }

            if (mediumArmor)
            {
                playerArmor.GetArmor(10, gameObject);
            }

            
        }
    }
}
