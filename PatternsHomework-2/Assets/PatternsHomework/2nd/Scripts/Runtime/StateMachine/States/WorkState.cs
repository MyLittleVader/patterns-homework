using UnityEngine;

namespace SecondTask
{
    public class WorkState : NPCState
    {
        private readonly WorkConfig _config;
        
        private float _remainedTime;

        public WorkState(NPCStateMachine stateMachine, NPCStateMachineData data, NPC npc) : base(stateMachine, data,
            npc) => _config = npc.Config.WorkConfig;
        
        public override void Enter()
        {
            base.Enter();

            _remainedTime = _config.WorkTime;
        }

        public override void Update()
        {
            base.Update();
            
            float deltaTime = Time.deltaTime;
            _remainedTime -= deltaTime;

            if (_remainedTime <= 0)
                SwitchToNextState();
        }

        public override void Exit()
        {
            base.Exit();
        }

        protected override void SwitchToNextState()
        {
            StateMachine.SwitchState<GoToRestState>();
        }
    }
}