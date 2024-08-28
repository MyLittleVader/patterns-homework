using UnityEngine;

namespace SecondTask
{
    public abstract class NPCState : IState
    {
        protected readonly NPCStateMachine StateMachine;
        protected readonly NPCStateMachineData Data;
        protected readonly NPC NPC;
        
        public NPCState(NPCStateMachine stateMachine, NPCStateMachineData data, NPC npc)
        {
            StateMachine = stateMachine;
            Data = data;
            NPC = npc;
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