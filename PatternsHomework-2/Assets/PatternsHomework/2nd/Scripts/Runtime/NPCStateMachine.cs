using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondTask
{
    public class NPCStateMachine : IStateMachine
    {
        private List<IState> _states;
        private IState _currentState;

        public NPCStateMachine(NPC npc)
        {
            NPCStateMachineData data = new NPCStateMachineData();
            
            _states = new List<IState>()
            {
                new GoToWorkState(this, data, npc),
                new WorkState(this, data, npc),
                new GoToRestState(this, data, npc),
                new RestState(this, data, npc),
            };

            _currentState = _states[0];
            _currentState.Enter();
        }
        
        public void SwitchState<T>() where T : IState
        {
            IState state = _states.FirstOrDefault(state => state is T);

            if (state == null)
                throw new ArgumentNullException("No state of type " + typeof(T).Name);

            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }
        
        public void Update() => _currentState.Update();
    }
}