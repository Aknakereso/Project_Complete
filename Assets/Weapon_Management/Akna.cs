
using UnityEngine;

public class Akna : MonoBehaviour
{

    public int bab = 1000;


    // Update is called once per frame
    void Update()
    {
        
    }

   public  void GetBabbed(int hurt)
    {
        bab -= hurt;
        if (bab <= 0)
        {
            Destroy(gameObject);
        }
    }

}
