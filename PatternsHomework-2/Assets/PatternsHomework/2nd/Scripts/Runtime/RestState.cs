using UnityEngine;

namespace SecondTask
{
    public class RestState : NPCState
    {
        private readonly RestConfig _config;
        
        private float _remainedTime;

        public RestState(NPCStateMachine stateMachine, NPCStateMachineData data, NPC npc) : base(stateMachine, data,
            npc) => _config = npc.Config.RestConfig;

        public override void Enter()
        {
            base.Enter();
            
            _remainedTime = _config.RestTime;
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
            StateMachine.SwitchState<GoToWorkState>();
        }
    }
}