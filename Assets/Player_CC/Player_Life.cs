using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Life : MonoBehaviour
{

    public int maxHealth;
    int actualHealth;
    public int maxArmor;
    int actualArmor;


    void Start()
    {

        actualHealth = maxHealth;
        actualArmor = maxArmor;

        ScreenDataManager.instanceHandler.HealthReport(actualHealth);
        ScreenDataManager.instanceHandler.ArmorReport(actualArmor);


    }

   
    void Update()
    {
        if (actualHealth < 0) { actualHealth = 0; }
        if (actualArmor < 0) { actualArmor = 0; }

        if (Input.GetKeyDown(KeyCode.K))      
        {
            GetHurt(13);      
        }

    }

    public void GetHurt(int damage)
    {
        int decreasedDamage;

        if (actualArmor >= 0)
        {
            decreasedDamage = damage - actualArmor;

            actualArmor -= damage;


            if (decreasedDamage >= 0)
            {
                actualHealth -= decreasedDamage;
                actualArmor = 0;

            }

        }

        if (actualHealth <= 0)
        {
            actualHealth = 0;
        }

        ScreenDataManager.instanceHandler.HealthReport(actualHealth);
        ScreenDataManager.instanceHandler.ArmorReport(actualArmor);

    }

    public void GetHealth(int amount, GameObject pu)
    {
        if (actualHealth < maxHealth)
        {
            actualHealth += amount;

            if (actualHealth > maxHealth)
            {
                actualHealth = maxHealth;
            }

            Destroy(pu);

        }

        ScreenDataManager.instanceHandler.HealthReport(actualHealth);


    }


    public void GetArmor(int amount, GameObject pu)
    {
        if (actualArmor < maxArmor)
        {
            actualArmor += amount;

            if (actualArmor > maxArmor)
            {
                actualArmor = maxArmor;
            }

            Destroy(pu);

        }

        ScreenDataManager.instanceHandler.ArmorReport(actualArmor);

    }
}
