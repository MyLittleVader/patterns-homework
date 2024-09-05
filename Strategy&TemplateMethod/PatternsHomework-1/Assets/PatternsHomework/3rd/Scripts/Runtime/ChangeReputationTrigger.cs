using UnityEngine;

namespace ThirdTask
{
    public class ChangeReputationTrigger : MonoBehaviour
    {
        [SerializeField, Range(-100, 100)] private int changeReputationAmount = 0;
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out ReputationSystem reputationSystem))
            {
                reputationSystem.ChangeReputation(changeReputationAmount);
            }
        }
    }
}