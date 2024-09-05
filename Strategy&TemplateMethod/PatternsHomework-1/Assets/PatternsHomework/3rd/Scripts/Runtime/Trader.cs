using UnityEngine;

namespace ThirdTask
{
    public abstract class Trader : MonoBehaviour
    {
        [SerializeField, Range(0, 100)] private int _reputationToTrade = 0;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out ReputationSystem reputationSystem))
                return;

            if (CheckReputation(reputationSystem) == false)
            {
                Debug.Log("I don't want to trade with you!");
                return;
            }
            
            Trade();
        }

        private bool CheckReputation(ReputationSystem reputationSystem)
        {
            return reputationSystem.Reputation >= _reputationToTrade;
        }

        protected abstract void Trade();
    }
}