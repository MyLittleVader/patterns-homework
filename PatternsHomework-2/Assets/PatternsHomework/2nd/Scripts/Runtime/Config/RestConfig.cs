using UnityEngine;

namespace SecondTask
{
    [System.Serializable]
    public class RestConfig
    {
        [field: SerializeField] public Transform RestPlace { get; private set; }
        [field: SerializeField, Range(0f, 10f)] public float RestTime { get; private set; } = 5f;
    }
}