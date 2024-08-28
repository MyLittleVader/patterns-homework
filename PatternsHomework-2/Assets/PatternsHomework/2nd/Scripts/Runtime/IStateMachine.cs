namespace SecondTask
{
    public interface IStateMachine
    {
        void SwitchState<T>() where T : IState;
    }
}