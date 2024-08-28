using UnityEngine;

namespace SecondTask
{
    public class GoToRestState : GoToTargetState
    {
        private readonly RestConfig _config;
        private readonly NPCStateMachineData _data;

        public GoToRestState(NPCStateMachine stateMachine, NPCStateMachineData data, NPC npc) : base(stateMachine, data,
            npc)
        {
            _config = npc.Config.RestConfig;
            _data = data;
        }

        public override void Enter()
        {
            base.Enter();
            
            _data.Target = _config.RestPlace;
        }

        protected override void SwitchToNextState()
        {
            StateMachine.SwitchState<RestState>();
        }
    }
}