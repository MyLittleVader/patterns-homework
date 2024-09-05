public class RunningState : MovingState
{
    private readonly RunningStateConfig _config;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RunningStateConfig;

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
        {
            StateSwitcher.SwitchState<IdlingState>();
            return;
        }
        if (WantsToSprint())
        {
            StateSwitcher.SwitchState<SprintingState>();
            return;
        }
        if (WantsToWalk())
        {
            StateSwitcher.SwitchState<WalkingState>();
            return;
        }
    }
    
    protected override void StartAnimation()
    {
        base.StartAnimation();
        
        View.StartRunning();
    }

    protected override void StopAnimation()
    {
        base.StopAnimation();
        
        View.StopRunning();
    }

    protected override float GetMovingSpeed()
    {
        return _config.Speed;
    }
}
