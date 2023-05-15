using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public int cyanBalls;
    public int redBalls;


    public PlayerData(Player_collectStuffs playerItems)
    {

        cyanBalls = playerItems.cyanBalls;
        redBalls = playerItems.redBalls;




    }


}
