using System.Collections.Generic;
using UnityEngine;

public class weaponHandler : MonoBehaviour
{
   
   public List<GameObject> arms = new List<GameObject>();


   public bool firstIsActive;
   public bool secondIsActive;

    // we have theese weapons:   
    public bool weHaveFirst;
    public bool weHaveSecond;

    private void Start()
    {
        SwitchOff();
        weHaveFirst = true;

       
    }

    void Update()
    {

        WeaponInHand();
        
  
    }
    void SwitchOff()
    {

        foreach (GameObject arm in this.arms)
        {
            arm.SetActive(false);

        }
    }

    void WeaponInHand()
    {
        
        if (!firstIsActive && Input.GetKeyDown(KeyCode.Alpha0) && weHaveFirst)
        {

            SwitchOff();
            arms[0].SetActive(true);

           

            firstIsActive = true;
            secondIsActive = false;
        }
       

        if (!secondIsActive && Input.GetKeyDown(KeyCode.Alpha1) && weHaveSecond)
        {
            SwitchOff();
            arms[1].SetActive(true);


            secondIsActive = true;
            firstIsActive = false;
  
        }
    
    }

    public void GetWweaponized(int weaponPickedUp, GameObject weapon)  // 0és 3 közti érték, mely utal a felvett fegyverre
    {
        if (weaponPickedUp == 1)
        {
            weHaveFirst = true;

            Destroy(weapon);
        }
        else if (weaponPickedUp == 2)
        {
            weHaveSecond = true;

            Destroy(weapon);
        }
        else
        {
            return;
        
        }

    }




}
