using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class FileSystem
{
    private const string fileName = "playerData.json";

    public static void Save(PlayerData data)
    {
        string filePath = Path.Combine(Application.dataPath, "Resources", fileName);

        string jsonData = JsonUtility.ToJson(data);

        File.WriteAllText(filePath, jsonData);
    }

    public static PlayerData LoadPlayerData()
    {
        string filePath = Path.Combine(Application.dataPath, "Resources", fileName);

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);

            PlayerData data = JsonUtility.FromJson<PlayerData>(jsonData);

            return data;
        }
        else
        {
            return new PlayerData();
        }
    }
}

public class PlayerData
{
    public List<int> scores = new List<int>();
}