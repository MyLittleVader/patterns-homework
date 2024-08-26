using UnityEngine;

namespace FourthTask
{
    public class FourthTaskBootstrapper : MonoBehaviour
    {
        public void Bootstrap(GameModeSelection gameMode)
        {
            if (gameMode == GameModeSelection.allBalls)
            {
                
            }
            else if (gameMode == GameModeSelection.greenBalls)
            {
                
            }
            else if (gameMode == GameModeSelection.redBalls)
            {
                
            }
            else if (gameMode == GameModeSelection.whiteBalls)
            {
                
            }
            else
            {
                Debug.Log("Undefined game mode");
                return;
            }
        }
    }
}