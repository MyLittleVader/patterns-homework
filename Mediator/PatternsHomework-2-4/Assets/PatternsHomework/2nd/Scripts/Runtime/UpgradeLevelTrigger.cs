using UnityEngine;

namespace SecondTask
{
    public class UpgradeLevelTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var playerState = other.GetComponentInParent<PlayerState>();
            
            if (playerState == null)
                return;
            
            playerState.UpgradeLevel();
        }
    }
}
