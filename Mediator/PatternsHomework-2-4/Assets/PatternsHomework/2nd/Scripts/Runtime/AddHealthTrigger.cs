using UnityEngine;

namespace SecondTask
{
    public class AddHealthTrigger : MonoBehaviour
    {
        [SerializeField, Range(0f, 100f)] private float _healAmount = 10f;
        
        private void OnTriggerEnter(Collider other)
        {
            var playerState = other.GetComponentInParent<PlayerState>();
            
            if (playerState == null)
                return;
            
            playerState.AddHealth(_healAmount);
        }
    }
}
