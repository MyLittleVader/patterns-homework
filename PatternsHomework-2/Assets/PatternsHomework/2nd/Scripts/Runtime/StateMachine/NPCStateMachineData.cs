using UnityEngine;

namespace SecondTask
{
    public class NPCStateMachineData
    {
        private Transform _target;
        
        public Transform Target
        {
            get => _target;
            set
            {
                if (value == null)
                    throw new System.ArgumentNullException(nameof(value), "Provided target is null!");

                _target = value;
            }
        }
    }
}