using UnityEngine;

namespace SecondTask
{
    public class SecondTaskBootstrapper : MonoBehaviour
    {
        [SerializeField] private Player _playerPrefab;

        private void Start()
        {
            if (_playerPrefab == null)
                return;
            
            var player = Instantiate(_playerPrefab);
        }
    }
}