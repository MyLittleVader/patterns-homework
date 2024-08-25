using UnityEngine;

public class SecondTaskBootstrapper : MonoBehaviour 
{
    [SerializeField] private GameObject _playerPrefab;
    private void Start()
    {
        Instantiate<GameObject>(_playerPrefab);
    }
}