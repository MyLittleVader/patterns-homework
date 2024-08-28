using UnityEngine;

namespace SecondTask
{
    [System.Serializable]
    public class NPCConfig
    {
        [field: SerializeField] public MovementConfig MovementConfig { get; private set; } = new MovementConfig();
        [field: SerializeField] public WorkConfig WorkConfig { get; private set; } = new WorkConfig();
        [field: SerializeField] public RestConfig RestConfig { get; private set; } = new RestConfig();
    }
}