
using UnityEngine;

public class AmmunationPickUp : MonoBehaviour
{

    
    [SerializeField] AimerShooter aimerShooter;
    [SerializeField] BazookaHandler bazookahandler;

    public bool bazooka;
    public bool pistol;
    public bool shotgun;


    public bool medium;
    public bool small;

    public int ammoMedium;
    public int ammoSmall;


    private void Update()
    {
        transform.rotation = aimerShooter.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (medium)
            {
                if (bazooka)
                {
                    bazookahandler.GetAmmo(ammoMedium, gameObject);
                }

                if (pistol) // pistol
                {
                    aimerShooter.PickUpPistolAmmo(ammoMedium, gameObject);

                }

                if (shotgun)  // shotgun
                {
                    aimerShooter.PickUpShotgunAmmo(ammoMedium, gameObject);
                }

            }
            if(small)
            {
                if (bazooka)
                {
                    bazookahandler.GetAmmo(ammoSmall, gameObject);
                }

                if (pistol) // pistol
                {
                    aimerShooter.PickUpPistolAmmo(ammoSmall, gameObject);

                }

                if (shotgun)  // shotgun
                {
                    aimerShooter.PickUpShotgunAmmo(ammoSmall, gameObject);
                }

            }
        }
        else {return;}

    }
    


}
