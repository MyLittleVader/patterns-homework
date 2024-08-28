using UnityEngine;

namespace SecondTask
{
    public class GoToWorkState : GoToTargetState
    {
        private readonly WorkConfig _config;

        public GoToWorkState(NPCStateMachine stateMachine, NPCStateMachineData data, NPC npc) : base(stateMachine, data,
            npc)
        {
            _config = npc.Config.WorkConfig;
        }
        
        public override void Enter()
        {
            base.Enter();
            
            Data.Target = _config.WorkPlace;
        }

        protected override void SwitchToNextState()
        {
            StateMachine.SwitchState<WorkState>();
        }
    }
}