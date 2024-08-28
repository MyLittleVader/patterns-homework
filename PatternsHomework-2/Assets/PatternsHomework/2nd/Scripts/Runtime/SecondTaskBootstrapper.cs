using UnityEngine;

namespace SecondTask
{
    public class SecondTaskBootstrapper : MonoBehaviour
    {
        [SerializeField] private NPC _npcPrefab;
        [SerializeField] private Transform _npcSpawnTransform;
        [SerializeField] private NPCConfig _npcConfig;
    
        private void Start()
        {
            var npc = Instantiate<NPC>(_npcPrefab, _npcSpawnTransform.position, _npcSpawnTransform.rotation);
            npc.Initialize(_npcConfig);
        }
    }
}
