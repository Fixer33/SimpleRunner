using UnityEngine;

[System.Serializable]
public class GameData
{
    public int CoinCount = 0;
    public int RestartCount = 0;

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }
    public static GameData FromJson(string json)
    {
        GameData result = JsonUtility.FromJson<GameData>(json);
        if (result == null)
            result = new GameData();
        return result;
    }
}
