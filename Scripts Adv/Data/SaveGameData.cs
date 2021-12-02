using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveGameData
{
    public static void SavePlayer (LevelManager levelManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelManager data = new LevelManager();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    // public static Player LoadPlayer ()
    // {
    //     string path = Application.persistentDataPath + "/player.fun";
    //     if (File.Exists(path))
    //     {
    //         BinaryFormatter formatter = new BinaryFormatter();
    //         FileStream stream = new FileStream(path, FileMode.Open);

    //         Player data = formatter.Deserialize(stream) as Player;
    //         stream.Close();

    //         return data;
    //     } else
    //     {
    //         Debug.LogError("Save file not found in " + path);
    //         return null;
    //     }
    // }
}
