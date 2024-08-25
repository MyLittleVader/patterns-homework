using UnityEngine;

namespace ThirdTask
{
    public class ReputationSystem : MonoBehaviour
    {
        [SerializeField, Range(0, 100)] private int _reputation = 0;

        public int Reputation => _reputation;

        public void ChangeReputation(int value)
        {
            _reputation += value;
            _reputation = Mathf.Clamp(_reputation, 0, 100);
        }
    }
}