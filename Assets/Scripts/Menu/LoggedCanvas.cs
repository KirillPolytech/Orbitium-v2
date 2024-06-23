using TMPro;
using UnityEngine;

public class LoggedCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Nick;
    [SerializeField] private TextMeshProUGUI Time;
    [SerializeField] private TextMeshProUGUI Orbs;

    public void SetPlayerData(PlayerData logData)
    {
        Nick.text = logData.Nick;
        Time.text = "Time: " + logData.Time;
        Orbs.text = "Orbs: " + logData.Orbs;
    }
}