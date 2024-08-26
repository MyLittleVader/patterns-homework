using UnityEngine;

namespace SecondTask
{
    public class SingleshotFireStrategy : IFireStrategy
    {
        private int _ammo;
        private float _strayFactor;
        private float _range;

        public SingleshotFireStrategy(int ammo, float strayFactor, float range)
        {
            _ammo = Mathf.Clamp(ammo, 0, int.MaxValue);
            _strayFactor = Mathf.Clamp(strayFactor, 0f, float.MaxValue);
            _range = Mathf.Clamp(range, 0f, float.MaxValue);
        }
        
        public void Fire()
        {
            if (_ammo <= 0) return;
            
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

            _ammo -= 1;
            Debug.Log($"SingleFire ammo left: {_ammo}");
        }
    }
}