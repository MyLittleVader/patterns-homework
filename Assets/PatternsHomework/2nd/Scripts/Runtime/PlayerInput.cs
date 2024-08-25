using UnityEngine;
using UnityEngine.Events;

namespace SecondTask
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private UnityEvent<int> _onWeaponSelection;
        [SerializeField] private UnityEvent _onWeaponFire;
        
        private void Update()
        {
            // Selected weapon change
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _onWeaponSelection?.Invoke(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _onWeaponSelection?.Invoke(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _onWeaponSelection?.Invoke(2);
            }
            
            // Weapon shoot
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _onWeaponFire?.Invoke();
            }
        }
    }
}