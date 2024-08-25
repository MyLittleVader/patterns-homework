using UnityEngine;

namespace SecondTask
{
    public class Gun : MonoBehaviour
    {
        private IFireStrategy _fireStrategy;

        public void SetFireStrategy(IFireStrategy fireStrategy)
        {
            _fireStrategy = fireStrategy;
        }
        
        public void Fire()
        {
            _fireStrategy?.Fire();
        }
    }
}