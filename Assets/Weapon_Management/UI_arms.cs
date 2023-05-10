
using UnityEngine;

public class UI_arms : MonoBehaviour
{       //    first

    weaponHandler weaponHandler;

   public Animator weaponUI;

    AudioSource audioI;

    //Cooldown:
    float timeBetweenShots = 2.2f;
    float actionTime;

    // Ammunation:
    int maxAmmo = 10;
    int actualAmmo;

  

    //bool, lõhetünk:
   
   public bool youCanClick;

    private void Awake()
    {
      //  weaponHandler = GetComponentInParent<weaponHandler>();
       // weaponHandler.arms.Add(gameObject);
    }

    void Start()
    {
        actualAmmo = maxAmmo;
        

        

        audioI = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if (actualAmmo <= 0)
        {
            actualAmmo = 0;    
        }


        if (actualAmmo > 0)
        {

            if (weaponUI.GetCurrentAnimatorStateInfo(0).IsName("UIweapon_Idle") || weaponUI.GetCurrentAnimatorStateInfo(0).IsName("UIweapon_recoil"))
            {
                youCanClick = true;
            }
            else { youCanClick = false; }


        }
        else { youCanClick = false; }

         
          
        
     
        if (youCanClick && Input.GetMouseButtonDown(0) && Time.time > actionTime + timeBetweenShots)
        {
            actualAmmo--;           
            audioI.Play();

            weaponUI.SetTrigger("Bang");
            actionTime = Time.time;
            

        }


     

    }
   

    public void GetAmmo(int amount, GameObject ammoPack)  // folytatni az Ammo pickupot
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
        youCanClick = false;

    }



}
