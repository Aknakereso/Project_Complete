
using UnityEngine;

public class PlayerPocket : MonoBehaviour
{
    // Keys
    public bool weHaveRedKey;
    public bool weHaveYellowKey;
    public bool weHaveBlueKey;


    private void Start()
    {
        ScreenDataManager.instanceHandler.ClearKeys();
    }

   
}
