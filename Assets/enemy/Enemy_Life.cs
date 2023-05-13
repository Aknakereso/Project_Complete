
using UnityEngine;

public class Enemy_Life : MonoBehaviour
{

    public int enemyHealthValue = 10;
    int actualValue;


  



    void Start()
    {
        actualValue = enemyHealthValue;
    }



   public void DecreaseHealth(int minus)
    {
        actualValue -= minus;
        if (actualValue <= 0)
        { Destroy(gameObject); }
    
    }

}
