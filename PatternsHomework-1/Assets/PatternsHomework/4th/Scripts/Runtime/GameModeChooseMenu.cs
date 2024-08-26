using UnityEngine;
using UnityEngine.Events;

namespace FourthTask
{
    public enum GameModeSelection
    {
        allBalls,
        greenBalls,
        redBalls,
        whiteBalls
    }
    
    public class GameModeChooseMenu : MonoBehaviour
    {
        private UnityEvent<GameMode> _onGameModeChoose;
        
        public void ChooseGameMode(GameMode gameMode)
        {
            _onGameModeChoose.Invoke(gameMode);
        }
    }
}