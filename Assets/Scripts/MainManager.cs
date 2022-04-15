using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Color TeamColor;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    [System.Serializable]
    class DataSave
    {
        public Color TeamColor;

    }
    public void SaveColor()
    {
        DataSave data = new DataSave();

        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath+ "/savefile.json", json);

        Debug.Log(Application.persistentDataPath);
        Debug.Log(json);
    }
    public void LoadColor(){
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataSave save = JsonUtility.FromJson<DataSave>(json);

            TeamColor = save.TeamColor;
        }
    }
}
