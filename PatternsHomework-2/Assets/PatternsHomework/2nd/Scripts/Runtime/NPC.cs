using UnityEngine;

namespace SecondTask
{
    [RequireComponent(typeof(CharacterController))]
    public class NPC : MonoBehaviour
    {
        private NPCConfig _config;
        private CharacterController _characterController;
        private NPCStateMachine _stateMachine;

        private bool isInit = false;

        public NPCConfig Config => _config;  
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
            _config = config;
            
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