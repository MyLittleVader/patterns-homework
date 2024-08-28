using UnityEngine;

namespace SecondTask
{
    public abstract class NPCState : IState
    {
        protected readonly NPCStateMachine StateMachine;
        protected readonly NPCStateMachineData Data;
        private readonly NPC _npc;
        
        public NPCState(NPCStateMachine stateMachine, NPCStateMachineData data, NPC npc)
        {
            StateMachine = stateMachine;
            Data = data;
            _npc = npc;
        }

        public virtual void Enter()
        {
            Debug.Log(GetType());
        }

        public virtual void Update()
        {
            
        }

        public virtual void Exit()
        {
            
        }
        
        protected abstract void SwitchToNextState();
    }
}