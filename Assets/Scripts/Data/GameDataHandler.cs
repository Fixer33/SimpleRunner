using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDataHandler : MonoBehaviour
{
    public static GameDataHandler Instance { get; private set; }

    [SerializeField] private string FileName = "Data.json";

    public GameData Data { get; private set; }

    private string _path = "";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        _path = Path.Combine(Application.persistentDataPath, FileName);
        LoadData();
    }
    private void Start()
    {
        Events.CoinPicked.AddListener(OnCoinPickUp);
    }
    private void OnDestroy()
    {
        SaveData();
        Events.CoinPicked.RemoveListener(OnCoinPickUp);
    }
#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
            return;

        SaveData();
    }
#else
    private void OnApplicationQuit()
    {
        SaveData();
    }
#endif

    private void OnCoinPickUp()
    {
        Data.CoinCount++;
    }

    #region Save / Load
    private void SaveData()
    {
        if (File.Exists(_path))
            File.Delete(_path);

        File.Create(_path).Close();

        string json = Data.ToJson();
        File.WriteAllText(_path, json);
        Debug.Log("Data saved");
    }
    private void LoadData()
    {
        if (File.Exists(_path) == false)
        {
            Data = new GameData();
            Debug.Log("No file found, creating new data");
            return;
        }

        string json = File.ReadAllText(_path);
        Data = GameData.FromJson(json);
        Debug.Log("Data loaded");
    } 
    #endregion
}
