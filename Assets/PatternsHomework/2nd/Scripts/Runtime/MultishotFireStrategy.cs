using UnityEngine;

namespace SecondTask
{
    public class MultishotFireStrategy : IFireStrategy
    {
        private int _ammo;
        private float _strayFactor;
        private float _range;
        private int _burst;

        public MultishotFireStrategy(int ammo, float strayFactor, float range, int burst)
        {
            _ammo = Mathf.Clamp(ammo, 0, int.MaxValue);
            _strayFactor = Mathf.Clamp(strayFactor, 0f, float.MaxValue);
            _range = Mathf.Clamp(range, 0f, float.MaxValue);
            _burst = Mathf.Clamp(burst, 0, int.MaxValue);
        }
        
        public void Fire()
        {
            if (_ammo < _burst) return;
            
            for (int index = 0; index < _burst; index++)
            {
                var firePosition = Camera.main.transform.position;
                
                var randomNumberX = Random.Range(-_strayFactor, _strayFactor);
                var randomNumberY = Random.Range(-_strayFactor, _strayFactor);
                var randomNumberZ = Random.Range(-_strayFactor, _strayFactor);
                var spreadVector = new Vector3(randomNumberX, randomNumberY, randomNumberZ);
                var fireDirection = Camera.main.transform.forward + spreadVector;
                
                RaycastHit hit;
                if (Physics.Raycast(firePosition, fireDirection, out hit, _range))
                {
                    Object.Instantiate(Resources.Load<BulletHole>("PatternsHomework/2nd/BulletHole"), hit.point, Quaternion.identity);
                }
            }
            
            _ammo -= _burst;
            Debug.Log($"MultishotFire ammo left: {_ammo}");
        }
    }
}