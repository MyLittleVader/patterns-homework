using UnityEngine;

namespace ThirdTask
{
    public class ThirdTaskBootstrapper : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform _playerSpawnpoint;
        
        [Header("Traders")]
        [SerializeField] private GameObject _emptyTraderPrefab;
        [SerializeField] private Transform _emptyTraderSpawnpoint;
        
        [Space(10)]
        
        [SerializeField] private GameObject _fruitsTraderPrefab;
        [SerializeField] private Transform _fruitsTraderSpawnpoint;
        
        [Space(10)]
        
        [SerializeField] private GameObject _armorTraderPrefab;
        [SerializeField] private Transform _armorTraderSpawnpoint;

        private void Start()
        {
            Instantiate<GameObject>(_playerPrefab, _playerSpawnpoint.position, _playerSpawnpoint.rotation);
            
            Instantiate<GameObject>(_emptyTraderPrefab, _emptyTraderSpawnpoint.position, _emptyTraderSpawnpoint.rotation);
            Instantiate<GameObject>(_fruitsTraderPrefab, _fruitsTraderSpawnpoint.position, _fruitsTraderSpawnpoint.rotation);
            Instantiate<GameObject>(_armorTraderPrefab, _armorTraderSpawnpoint.position, _armorTraderSpawnpoint.rotation);
        }
    }
}