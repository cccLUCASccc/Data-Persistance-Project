using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public string name, bestplayerName;
    public int score, bestScore;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        charger();
    }

    private void Update()
    {
        if(bestScore < score)
        {
            bestScore = score;
            bestplayerName = name;
        }
    }
    public void sauvegarder()
    {
        DataToSave data = new DataToSave();
        data.name = bestplayerName;
        data.score = bestScore;
   
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void charger()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataToSave data = JsonUtility.FromJson<DataToSave>(json);

            bestplayerName = data.name;
            bestScore = data.score;
        }
    }
}
public class DataToSave
{
    public string name;
    public int score;
}
