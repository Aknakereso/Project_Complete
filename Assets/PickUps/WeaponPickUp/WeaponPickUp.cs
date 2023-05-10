
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{

    [SerializeField] AimerShooter aimerShooter;
    [SerializeField] BazookaHandler bazookahandler;

    
    public bool pistol;
    public bool shotgun;
    public bool bazooka;

    public int ammo;

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        { 
            if (bazooka )
             {

                aimerShooter.PickUpBazooka(bazooka ,gameObject);
                bazookahandler.GetAmmo(ammo, gameObject);


            }

            if (pistol) // pistol
            {
                aimerShooter.PickUpPistol(pistol, gameObject);
                aimerShooter.PickUpPistolAmmo(ammo, gameObject);

            }

            if (shotgun)  // shotgun
            {

                aimerShooter.PickUpShotgun(shotgun, gameObject);
                aimerShooter.PickUpShotgunAmmo(ammo, gameObject);

            }

        }
        





    }
}
