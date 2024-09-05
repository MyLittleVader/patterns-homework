using UnityEngine;

namespace SecondTask
{
    public class GoToRestState : GoToTargetState
    {
        private readonly RestConfig _config;

        public GoToRestState(NPCStateMachine stateMachine, NPCStateMachineData data, NPC npc) : base(stateMachine, data,
            npc)
        {
            _config = npc.Config.RestConfig;
        }

        public override void Enter()
        {
            base.Enter();
            
            Data.Target = _config.RestPlace;
        }

        protected override void SwitchToNextState()
        {
            StateMachine.SwitchState<RestState>();
        }
    }
}