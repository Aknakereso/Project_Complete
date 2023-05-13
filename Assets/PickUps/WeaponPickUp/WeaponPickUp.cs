
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{

    [SerializeField] AimerShooter aimerShooter;
    [SerializeField] BazookaHandler bazookahandler;

    
    public bool pistol;
    public bool shotgun;
    public bool bazooka;

    public int ammo;

    private void Update()
    {
        if (!bazooka)
        {
            transform.rotation = aimerShooter.transform.rotation;
        }
        


    }



    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        { 
            if (bazooka )
             {

                aimerShooter.PickUpBazooka(bazooka ,gameObject);
                bazookahandler.GetAmmo(ammo, gameObject);


            }

            if (pistol)
            {
                aimerShooter.PickUpPistol(pistol, gameObject);
                aimerShooter.PickUpPistolAmmo(ammo, gameObject);

            }

            if (shotgun)
            {

                aimerShooter.PickUpShotgun(shotgun, gameObject);
                aimerShooter.PickUpShotgunAmmo(ammo, gameObject);

            }

        }
        





    }
}
