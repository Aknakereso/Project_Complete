using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIarms_II : MonoBehaviour
{    //      Second

    weaponHandler weaponHandler;

   public Animator weaponUI_II;

    AudioSource audioII;

    float timeBetweenShots = 0.25f;
    float actionTime;


    //ammunation:
    int maxAmmo = 10;
    int actualAmmo;

  

    //booL:
   public bool youCanClickII;

    private void Awake()
    {
        //weaponHandler = GetComponentInParent<weaponHandler>();
       // weaponHandler.arms.Add(gameObject);
    }



    void Start()
    {
       actualAmmo = maxAmmo;


        

        audioII = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (actualAmmo > 0)
        {
            if (weaponUI_II.GetCurrentAnimatorStateInfo(0).IsName("UIweaponII_Idle") || weaponUI_II.GetCurrentAnimatorStateInfo(0).IsName("UIweaponII_recoil"))
            {
 
              youCanClickII = true;
            }
             else { youCanClickII = false; }

        }
        else { youCanClickII = false; }

       
    
    

        if (youCanClickII &&  Input.GetMouseButtonDown(0) && Time.time > actionTime + timeBetweenShots)
        {
            actualAmmo--;
            audioII.Play();

            weaponUI_II.SetTrigger("Bang");
            actionTime = Time.time;
           
        }

       
    }

   

    public void GetAmmoII( int amount, GameObject ammoPack)
    {

        if (actualAmmo < maxAmmo)
        {

            actualAmmo += amount;

            if (actualAmmo > maxAmmo)
            {
                actualAmmo = maxAmmo;
            }

            Destroy(ammoPack);

        }
 
    }



    private void OnDisable()
    {
        youCanClickII = false;

    }
}
