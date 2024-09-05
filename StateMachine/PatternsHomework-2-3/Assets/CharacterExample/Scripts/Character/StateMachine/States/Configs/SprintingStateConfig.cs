using UnityEngine;

[System.Serializable]
public class SprintingStateConfig
{
    [field: SerializeField, Range(0, 10)] public float Speed { get; private set; }  
}
