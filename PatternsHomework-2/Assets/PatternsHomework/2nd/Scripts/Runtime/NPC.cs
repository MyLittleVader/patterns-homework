using UnityEngine;

namespace SecondTask
{
    [RequireComponent(typeof(CharacterController))]
    public class NPC : MonoBehaviour
    {
        private CharacterController _characterController;
        private NPCStateMachine _stateMachine;

        private bool isInit = false;

        public NPCConfig Config { get; private set; }
        public CharacterController CharacterController
        {
            get
            {
                if (_characterController == null)
                    _characterController = GetComponent<CharacterController>();
                
                return _characterController;
            }
        }
        
        public void Initialize(NPCConfig config)
        {
            Config = config;
            
            _stateMachine = new NPCStateMachine(this);
            isInit = _stateMachine != null;
        }

        private void Update()
        {
            if (!isInit) return;
            
            _stateMachine?.Update();
        }
    }
}