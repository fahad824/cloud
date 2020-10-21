using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SavToBytes : MonoBehaviour
{
    public static string FileName = "/Cloud.systemsaveinfo";
    public static void SaveLoginData(User playerLoginData)
    {
        BinaryFormatter bF = new BinaryFormatter();

        string path = Application.persistentDataPath + FileName;
        FileStream filestream = new FileStream(path, FileMode.Create);
        bF.Serialize(filestream, playerLoginData);
        filestream.Close();


    }

    public static User GetLoginData()
    {
        string path = Application.persistentDataPath + FileName;
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);

            User playerLoginData = bf.Deserialize(file) as User;
            file.Close();
            return playerLoginData;
        }
        else
        {
            Debug.LogError("PlayerLogInData File could not be found");
            return null;
        }







    }
}

