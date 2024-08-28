using UnityEngine;

namespace SecondTask
{
    public class GoToWorkState : GoToTargetState
    {
        private readonly WorkConfig _config;
        private readonly NPCStateMachineData _data;

        public GoToWorkState(NPCStateMachine stateMachine, NPCStateMachineData data, NPC npc) : base(stateMachine, data,
            npc)
        {
            _config = npc.Config.WorkConfig;
            _data = data;
        }
        
        public override void Enter()
        {
            base.Enter();
            
            _data.Target = _config.WorkPlace;
        }

        protected override void SwitchToNextState()
        {
            StateMachine.SwitchState<WorkState>();
        }
    }
}