using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(DataPlayer player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.farm";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerStatistic data = new PlayerStatistic(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerStatistic LoadPlayer(){
        string path = Application.persistentDataPath + "/player.farm";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerStatistic data = formatter.Deserialize(stream) as PlayerStatistic;
            stream.Close();

            return data;
        } else {
            Debug.LogError("Save File not found in: " + path);
            return null;
        }
    }
}
