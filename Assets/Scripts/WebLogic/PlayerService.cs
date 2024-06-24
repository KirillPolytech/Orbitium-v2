using UnityEngine;

namespace Web
{
    public enum PlayerStatus { logged, unlogged }
    public class PlayerService : MonoBehaviour
    {
        public PlayerData PlayerData { get; } = new PlayerData() { Nick = null, Time = 0, Orbs = 0 };

        public PlayerStatus Status { get; private set; } = PlayerStatus.unlogged;

        private WebUIController _controller;

        private void Awake()
        {
            _controller = FindAnyObjectByType<WebUIController>();
        }

        public void UpdateData(PlayerData data)
        {
            if (data.Nick == null)
                return;
            
            PlayerData.Nick ??= data.Nick;            

            PlayerData.Orbs += data.Orbs;

            if (PlayerData.Time < data.Time)
            {
                PlayerData.Time = data.Time;
            }

            _controller.SetPlayerData(PlayerData);

            Status = PlayerStatus.logged;
        }
    }
}