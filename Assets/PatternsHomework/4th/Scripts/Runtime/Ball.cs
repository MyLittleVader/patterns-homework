using UnityEngine;
using UnityEngine.Events;

namespace FourthTask
{
    public enum BallColor
    {
        Green,
        Red,
        White
    }
    
    public class Ball : MonoBehaviour
    {
        private UnityEvent<Ball> _onBallPickup;
        
        [SerializeField] private BallColor _ballColor = BallColor.Green;
        
        public BallColor BallColor => _ballColor;
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IBallPicker ballPicker))
            {
                _onBallPickup.Invoke(this);
            }
            
            Destroy(gameObject);
        }

        public void StartTracking(UnityAction<Ball> onBallPickup)
        {
            _onBallPickup.AddListener(onBallPickup);
        }

        public void StopTracking(UnityAction<Ball> onBallPickup)
        {
            _onBallPickup.RemoveListener(onBallPickup);
        }
    }
}