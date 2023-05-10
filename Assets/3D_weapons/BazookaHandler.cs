using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaHandler : MonoBehaviour
{
    Animator anim;
    AudioSource audio;

    [SerializeField] GameObject rocket;
    Rigidbody rocketRB;
    [SerializeField] float speed;
    [SerializeField] Transform exit;
    GameObject newRocket;


    string IDLE_III = "Bazooka_Idle";
    string WALK_III = "Bazooka_Walk";
    string RECOIL_III = "Bazooka_Recoil";


    public int maxBazookaAmmo;
    int actualBazookaAmmo;

    private void Awake()
    {
        actualBazookaAmmo += maxBazookaAmmo;
    }


    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();


        

    }

    // Update is called once per frame
    void Update()
    {       if (actualBazookaAmmo < 0)     {          actualBazookaAmmo = 0;       }


        BazookaAnim();
        RocketLaunch();



    }

    void BazookaAnim()
    {

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Walk", true);

        }
        else { anim.SetBool("Walk", false); }

    }


    void RocketLaunch()
    {
        bool readyToLaunch = anim.GetCurrentAnimatorStateInfo(0).IsName(IDLE_III) || anim.GetCurrentAnimatorStateInfo(0).IsName(RECOIL_III) || anim.GetCurrentAnimatorStateInfo(0).IsName(WALK_III);


        if (readyToLaunch && actualBazookaAmmo > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Bang");
                audio.Play();

                newRocket = Instantiate(rocket, exit.position, exit.rotation);
                newRocket.SetActive(true);
                rocketRB = newRocket.GetComponent<Rigidbody>();
                rocketRB.velocity = transform.forward * speed;

                actualBazookaAmmo--;

                ScreenDataManager.instanceHandler.BazookaAmmunationReport(actualBazookaAmmo);

            }

        }

    }


    public void GetAmmo(int value, GameObject pu)
    {
        if (actualBazookaAmmo < maxBazookaAmmo)
        {

            actualBazookaAmmo += value;

            if (actualBazookaAmmo > maxBazookaAmmo)
            {
                actualBazookaAmmo = maxBazookaAmmo;
            }

            Destroy(pu);

        }
        else { return; }

        ScreenDataManager.instanceHandler.BazookaAmmunationReport(actualBazookaAmmo);
    }


}
