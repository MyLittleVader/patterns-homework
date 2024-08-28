using UnityEngine;

namespace SecondTask
{
    [System.Serializable]
    public class MovementConfig
    {
        [field: SerializeField, Range(0f, 10f)] public float MoveSpeed { get; private set; } = 5f;
        [field: SerializeField, Range(0f, 1f)]  public float ApproachDistance { get; private set; } = 0.05f;
    }
}