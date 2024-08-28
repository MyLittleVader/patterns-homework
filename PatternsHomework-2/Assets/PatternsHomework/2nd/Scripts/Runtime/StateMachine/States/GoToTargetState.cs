using UnityEngine;

namespace SecondTask
{
    public abstract class GoToTargetState : NPCState
    {
        private readonly MovementConfig _config;
        private readonly CharacterController _characterController;

        public GoToTargetState(NPCStateMachine stateMachine, NPCStateMachineData data, NPC npc) : base(stateMachine,
            data, npc)
        {
            _config = npc.Config.MovementConfig;
            _characterController = npc.CharacterController;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();
            
            Transform character = _characterController.transform;
            Transform target = Data.Target;
            
            Vector3 direction = (target.position - character.position).normalized;
            
            _characterController.Move(direction * (_config.MoveSpeed * Time.deltaTime));
            
            float distance = (target.position - character.position).sqrMagnitude;
            if (distance < _config.ApproachDistance * _config.ApproachDistance)
            {
                SwitchToNextState();
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}