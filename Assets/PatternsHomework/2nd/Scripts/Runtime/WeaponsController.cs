using UnityEngine;
using System.Collections.Generic;

namespace SecondTask
{
    [System.Serializable]
    public class AmmoInventory
    {
        private Dictionary<AmmoType, int> _storedAmmo;

        public AmmoInventory()
        {   
            
            _storedAmmo.Add(AmmoType._9x19, 255);
            _storedAmmo.Add(AmmoType._20ga, 255);
        }
    }

    public class WeaponsController : MonoBehaviour
    {
        private AmmoInventory _ammo;
        
        private void Awake() 
        {
            
        }

        private void Start() 
        {
            
        }
    }
}