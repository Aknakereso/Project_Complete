using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimerShooter : MonoBehaviour
{



    //Enemies:
    public Enemy_Life enemyLife;
    [Space]

    // weapons:
    // Pistol
    public Animator pistolAnim; 
    public AudioSource pistolAudio;
    string IDLE = "UIweapon_Idle";
    string RECOIL = "UIweapon_recoil";
    string FIRE = "UIweapon_fire";
   
    bool readyPistol;

    [SerializeField] int pistolDamage;
    // shotgun
    public Animator shotgunAnim;
    public AudioSource shotgunAudio;
    string IDLE_II = "UIweaponII_Idle";
    string RECOIL_II = "UIweaponII_recoil";
    string FIRE_II = "UIweaponII_fire";
    
    bool readyShotgun;

    [SerializeField] int shotgunDamage;

    // Bazooka

    public Animator bazookaAnim;
   
    string FIRE_III = "Bazooka_Fire";
    string RECOIL_III = "Bazooka_Recoil";
 

    //DMG,
    // stb. a saját script jén


 [Space]  
    // fegyverek:
  
    [SerializeField] GameObject[] weaponObjects = new GameObject[3]; // pistolAnim,shotgunAnim,sphere

     [SerializeField] bool weHavePistol;
     [SerializeField] bool weHaveShotgun;
     [SerializeField] bool weHaveBazooka;
   
    bool pistolPicked = false;
    bool shotgunPicked = false;
    bool bazookaPicked = false;

   
    [Space]

    // ammunations:
    public int maxPistolAmmo;
    int actualPistolAmmo;

    public int maxShotgunAmmo;
    int actualShotgunAmmo;

    // bazooakaAmmo...nem itt van


    [Space]


    // gizmos: 
    [SerializeField] float size;
    [SerializeField] float dist;


    private void Start()
    {
        
        ScreenDataManager.instanceHandler.PistolPickUp(weHavePistol);
        ScreenDataManager.instanceHandler.ShotgunPickUp(weHaveShotgun);
        ScreenDataManager.instanceHandler.BazookaPickUp(weHaveBazooka);


        SwitchOffWeapons();

        actualPistolAmmo = 2;
        actualShotgunAmmo = 7;

      ScreenDataManager.instanceHandler.AmmunationReport(actualPistolAmmo); 
      ScreenDataManager.instanceHandler.ShotgunAmmunationReport(actualShotgunAmmo);

    }
    void Update()
    {

        WeaponSelect();
        PistolShot();
        ShotgunShot();

        
    }



    void SwitchOffWeapons()
    {
        for (int i = 0; i < weaponObjects.Length; i++)
        {
            weaponObjects[i].SetActive(false);
       
        }   
    }

    bool WeCanPickThat()
    {
        bool Switch = true; // ???
        
                bool weaponUse = pistolAnim.GetCurrentAnimatorStateInfo(0).IsName(FIRE) || pistolAnim.GetCurrentAnimatorStateInfo(0).IsName(RECOIL);
                bool weaponUse_II = shotgunAnim.GetCurrentAnimatorStateInfo(0).IsName(FIRE_II) || pistolAnim.GetCurrentAnimatorStateInfo(0).IsName(RECOIL_II);
                bool weaponUse_III = bazookaAnim.GetCurrentAnimatorStateInfo(0).IsName(FIRE_III) || bazookaAnim.GetCurrentAnimatorStateInfo(0).IsName(RECOIL_III);

        if (weaponUse || weaponUse_II || weaponUse_III)
        {
        
            Switch = false;
        
        }      
       return Switch;

    }

   
   

    void WeaponSelect()  
    {      
        if (WeCanPickThat())
        { 
        
           if (Input.GetKeyDown(KeyCode.Alpha0) && weHavePistol && !pistolPicked)
           {             
            SwitchOffWeapons();          
            weaponObjects[0].SetActive(true);

                pistolPicked = true;

                shotgunPicked = false;
                bazookaPicked = false;

           }

           if (Input.GetKeyDown(KeyCode.Alpha1) && weHaveShotgun && !shotgunPicked)
           {
            SwitchOffWeapons();        
            weaponObjects[1].SetActive(true);

                shotgunPicked = true;

                pistolPicked = false;
                bazookaPicked = false;
           }

           if (Input.GetKeyDown(KeyCode.Alpha2) && weHaveBazooka && !bazookaPicked)
           {
            SwitchOffWeapons();  
            weaponObjects[2].SetActive(true);

                bazookaPicked = true;

                pistolPicked = false;
                shotgunPicked = false;
           }               
        }
       
    }



    bool WeCanShotPistol()
    {  if (pistolAnim.GetCurrentAnimatorStateInfo(0).IsName(IDLE) || pistolAnim.GetCurrentAnimatorStateInfo(0).IsName(RECOIL))
        {                       readyPistol = true;       }
       else {           readyPistol = false;     }
        return  readyPistol;
    }

    bool WeCanShotShotgun()
    {   if (shotgunAnim.GetCurrentAnimatorStateInfo(0).IsName(IDLE_II) || shotgunAnim.GetCurrentAnimatorStateInfo(0).IsName(RECOIL_II))
        {            readyShotgun = true;                }
        else {     readyShotgun = false;       }
        return readyShotgun;
    }

   


    void PistolShot()
    {           
        if ( weaponObjects[0].activeSelf && actualPistolAmmo > 0 && WeCanShotPistol() && Input.GetMouseButtonDown(0)  )
        {

          
            pistolAnim.SetTrigger("Bang");
            pistolAudio.Play();


            Ray myRay = new Ray(transform.position, transform.forward);
            bool hit = Physics.Raycast(myRay, out RaycastHit hitData);

            enemyLife = hitData.collider.GetComponent<Enemy_Life>();

            if (enemyLife != null)
            {

                Debug.Log("Pistol damagedENEMY");
                enemyLife.DecreaseHealth(pistolDamage);
            }
           

           
            actualPistolAmmo--;

            ScreenDataManager.instanceHandler.AmmunationReport(actualPistolAmmo); 
       

        }
        
  
    }

    void ShotgunShot()
    {         
        if ( weaponObjects[1].activeSelf && actualShotgunAmmo > 0 && WeCanShotShotgun() && Input.GetMouseButtonDown(0))
        {

            Debug.Log("shotgun shot");
            shotgunAnim.SetTrigger("Bang");
            shotgunAudio.Play();

            Ray myRay = new Ray(transform.position, transform.forward);
            bool hit = Physics.Raycast(myRay, out RaycastHit hitData);

            enemyLife = hitData.collider.GetComponent<Enemy_Life>();

            if (enemyLife != null)
            {

                Debug.Log("Shotgun damaged ENEMY");
                enemyLife.DecreaseHealth(shotgunDamage);
            }


            actualShotgunAmmo--;

          ScreenDataManager.instanceHandler.ShotgunAmmunationReport(actualShotgunAmmo); // SHOTGUN hoz csinálni



        } 
    }

    // Pick Ups:

   public void PickUpBazooka(bool t, GameObject wpu) //-----
   {
        if (!weHaveBazooka)
        {    weHaveBazooka = t;
            Destroy(wpu);
        }
        else { return; }

        ScreenDataManager.instanceHandler.BazookaPickUp(weHaveBazooka);
   }


    public void PickUpPistolAmmo(int ammo, GameObject pu)
    {
        if (actualPistolAmmo < maxPistolAmmo)
        {
            actualPistolAmmo += ammo;

            if (actualPistolAmmo > maxPistolAmmo)
            {
                actualPistolAmmo = maxPistolAmmo;

                Destroy(pu);

            }
           

         

            Destroy(pu);
        }
       

       ScreenDataManager.instanceHandler.AmmunationReport(actualPistolAmmo);


    }

    public void PickUpPistol(bool p,  GameObject pu ) // -----
    {
        if (!weHavePistol)
        {
            weHavePistol = p;

            ScreenDataManager.instanceHandler.PistolPickUp(weHavePistol);
            

            Destroy(pu);



        }
        else { return; }

        

    }



    public void PickUpShotgunAmmo(int ammo, GameObject pu)
    {

        if (actualShotgunAmmo < maxShotgunAmmo)
        {
            actualShotgunAmmo += ammo;

            if (actualShotgunAmmo > maxShotgunAmmo)
            {
                actualShotgunAmmo = maxShotgunAmmo;


                Destroy(pu);
            }
            else { return; }


            


            Destroy(pu);

            ScreenDataManager.instanceHandler.ShotgunAmmunationReport(actualShotgunAmmo); // amint max ammo t elérjük

        }
        else { return; }

       
    }

    public void PickUpShotgun(bool s, GameObject pu) // ------
    { 
    
        if (!weHaveShotgun)
        {
          weHaveShotgun = s;


           ScreenDataManager.instanceHandler.ShotgunPickUp(weHaveShotgun);

          Destroy(pu);

        }
        else { return; }
    
      
      
    }







    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 10f );

        Gizmos.DrawSphere(transform.position + transform.forward * dist, size);
    }
 
   
}
