using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class YandexIntegration : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void GetPlayerData();
    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);
    [DllImport("__Internal")]
    private static extern void LoadExtern();
    [DllImport("__Internal")]
    private static extern void SendToLeaderBoard(float value);
    [DllImport("__Internal")]
    private static extern void RateGame();

    [SerializeField] public TextMeshProUGUI PlayerNameText;
    [SerializeField] public TextMeshProUGUI PlayingTimeText;
    [SerializeField] public TextMeshProUGUI OrbsText;

    private float CurrentPlayingTime;
    private int CurrentOrbs;
    private float __playingTimeFromDataBase = 0;
    private int __orbsFromDataBase = 0;

    public static YandexIntegration Instance { get; private set; }
    private void Start()
    {
        if (Instance == null) { DontDestroyOnLoad(gameObject); Instance = this; } else { Destroy(gameObject); }
#if UNITY_WEBGL && !UNITY_EDITOR
        GetPlayerData();
        LoadExtern();

        PlayingTimeText.text = "" + __playingTimeFromDataBase;
        OrbsText.text = "" + __orbsFromDataBase;

        PlayerInfinity.GetInstance.EventAtDeath.AddListener(() => {RateGame();});
        
        Hello();
#endif
    }

    public void SetName(string name) // javascript
    {
        PlayerNameText.text = name;

        Debug.Log("Name supplied");
    }

    public void Save() // javascript
    {
        YandexPlayerData __data = new YandexPlayerData(CurrentPlayingTime, CurrentOrbs);

        string jsonString = JsonUtility.ToJson(__data);

        SaveExtern(jsonString);

        Debug.Log("record saved");
    }

    public void SetPlayerInfo(string value) // javascript
    {
        YandexPlayerData __data = JsonUtility.FromJson<YandexPlayerData>(value);

        __playingTimeFromDataBase = __data.Time;
        __orbsFromDataBase = __data.Orbs;

        Debug.Log("Player's info supplied");
    }

    public void SetData(PlayerData data) // javascript
    {
        PlayingTimeText.text = "" + data.Time;
        OrbsText.text = "" + data.Orbs;
    }

    public void SendDataToLeaderBoard(float time, int orbs)
    {
        if (time > __playingTimeFromDataBase)
        {
            CurrentPlayingTime = time;
            PlayingTimeText.text = "" + time;            

            Debug.Log("Time:" + time);
        }

        if (orbs > __orbsFromDataBase)
        {
            CurrentOrbs = orbs;
            OrbsText.text = "" + orbs;
            //SendToLeaderBoard(orbs);

            Debug.Log("Orbs:" + orbs);
        }

        SendToLeaderBoard(time);
        Save();
    }

}
public struct YandexPlayerData
{
    public float Time;
    public int Orbs;
    public YandexPlayerData(float time, int orbs)
    {
        Time = time; Orbs = orbs;
    }
}