
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class Save_system 
{
  


    public static  void SavePlayerItems(Player_collectStuffs playerItems)
    {

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/doomlikegamePlayerItemsCollected.pizza";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData playerItemsData = new PlayerData(playerItems);

        binaryFormatter.Serialize(stream, playerItemsData);
        stream.Close();





    }


    public static PlayerData Load ()
    {
        string path = Application.persistentDataPath + "/doomlikegamePlayerItemsCollected.pizza";

        if (File.Exists(path))
        {

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData pData = binaryFormatter.Deserialize(stream) as PlayerData;
            stream.Close();


            return pData;

        }
        else 
        {
            Debug.LogError("Save file not found " + path);
            return null;
        
        }

    }

}
