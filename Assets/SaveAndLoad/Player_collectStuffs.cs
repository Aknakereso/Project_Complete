
using UnityEngine;

public class Player_collectStuffs : MonoBehaviour
{

    public int cyanBalls;
    public int redBalls;



    void Start()
    {
        Debug.Log("Hello");
    }

    // Update is called once per frame
    void Update()
    {

       
    }


    public void PickUpCyanBalls(int value, GameObject pu)
    {

        cyanBalls += value;

        Destroy(pu);
    
    }

    public void PickUpRedBalls(int value, GameObject pu)
    {

        redBalls += value;

        Destroy(pu);

    }
}
