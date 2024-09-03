public abstract class MovingState : GroundedState
{
    public MovingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    { }
    
    public override void Enter()
    {
        base.Enter();

        Data.Speed = GetMovingSpeed();
        StartAnimation();
    }

    public override void Exit()
    {
        base.Exit();
        
        StopAnimation();
    }

    public override void Update()
    {
        base.Update();
    }

    protected virtual void StartAnimation()
    {
        View.StartMoving();
    }

    protected virtual void StopAnimation()
    {
        View.StopMoving();
    }

    protected abstract float GetMovingSpeed();
}