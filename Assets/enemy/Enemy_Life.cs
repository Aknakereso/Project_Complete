
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
        
        // szimpla mint�zat� "el vissza" mozg�s:


        // t�mad� mozg�s





    }

   public void DecreaseHealth(int minus)
    {
        actualValue -= minus;
        if (value <= 0)
        { Destroy(gameObject); }
    
    }

}
