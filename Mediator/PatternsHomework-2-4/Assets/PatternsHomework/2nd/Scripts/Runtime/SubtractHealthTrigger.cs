using UnityEngine;

namespace SecondTask
{
    public class SubtractHealthTrigger : MonoBehaviour
    {
        [SerializeField, Range(0f, 100f)] private float _damageAmount = 10f;
        
        private void OnTriggerEnter(Collider other)
        {
            var playerState = other.GetComponentInParent<PlayerState>();
            
            if (playerState == null)
                return;
            
            playerState.SubtractHealth(_damageAmount);
        }
    }
}
