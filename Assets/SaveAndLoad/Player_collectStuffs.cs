
using UnityEngine;

public class Player_collectStuffs : MonoBehaviour
{

    public int cyanBalls;
    public int redBalls;



    void Start()
    {
        Debug.Log("Hello");
    }



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {

            SaveData();
            Debug.Log("GameSaved");
        
        }

        if (Input.GetKeyDown(KeyCode.L))
        {

            LoadPlayer();
            Debug.Log("GameLoaded");

        }




    }
    



    public void SaveData()
    {

        Save_system.SavePlayerItems(this);
    
    }

    public void LoadPlayer()
    {

        PlayerData data = Save_system.Load();

        cyanBalls = data.cyanBalls;
        redBalls = data.redBalls;

    
    }

    public void NewGame()
    {
        cyanBalls = 0;
        redBalls = 0;

         SaveData();
    
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
