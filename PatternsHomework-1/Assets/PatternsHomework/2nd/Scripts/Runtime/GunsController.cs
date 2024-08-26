using UnityEngine;
using System.Collections.Generic;

namespace SecondTask
{
    public class GunsController : MonoBehaviour
    {
        private int _selectedGunIndex = 0;
        
        [SerializeField] private List<Gun> _guns = new List<Gun>();
        
        public void SelectWeapon(int newGunIndex)
        {
            _selectedGunIndex = Mathf.Clamp(newGunIndex, 0, _guns.Count);
            
            foreach (var gun in _guns)
            {
                gun.gameObject.SetActive(false);
            }
            _guns[_selectedGunIndex].gameObject.SetActive(true);
        }

        public void Fire()
        {
            _guns[_selectedGunIndex].Fire();
        }
    }
}