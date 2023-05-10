
using UnityEngine;

public class Enemy_Life : MonoBehaviour
{

    public int value = 10;
    int actualValue;


    Vector3 startPos;
    Vector3 startRotation; // Quaternionba



    void Start()
    {
        actualValue = value;

        startPos = transform.position;


    }

   
    void Update()
    {
        
        // szimpla mintázatú "el vissza" mozgás:


        // támadó mozgás





    }

   public void DecreaseHealth(int minus)
    {
        actualValue -= minus;
        if (value <= 0)
        { Destroy(gameObject); }
    
    }

}
