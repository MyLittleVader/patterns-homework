using UnityEngine;

namespace SecondTask
{
    [System.Serializable]
    public class WorkConfig
    {
        [field: SerializeField] public Transform WorkPlace { get; private set; }
        [field: SerializeField, Range(0f, 10f)] public float WorkTime { get; private set; } = 5f;
    }
}