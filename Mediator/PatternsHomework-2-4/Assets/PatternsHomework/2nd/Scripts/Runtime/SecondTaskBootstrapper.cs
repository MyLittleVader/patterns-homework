using UnityEngine;
using UnityEngine.Serialization;

namespace SecondTask
{
    public class SecondTaskBootstrapper : MonoBehaviour
    {
        [FormerlySerializedAs("_playerPrefab")] [SerializeField] private PlayerState playerStatePrefab;

        private void Start()
        {
            if (playerStatePrefab == null)
                return;
            
            var player = Instantiate(playerStatePrefab);
            player.Initialize();
        }
    }
}