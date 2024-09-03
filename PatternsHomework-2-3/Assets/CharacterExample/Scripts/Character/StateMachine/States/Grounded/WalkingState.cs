public class WalkingState : MovingState
{
    private readonly WalkingStateConfig _config;

    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.WalkingStateConfig;

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
        if (!WantsToWalk())
        {
            StateSwitcher.SwitchState<RunningState>();
            return;
        }
    }
    
    protected override void StartAnimation()
    {
        base.StartAnimation();
        
        View.StartWalking();
    }

    protected override void StopAnimation()
    {
        base.StopAnimation();
        
        View.StopWalking();
    }

    protected override float GetMovingSpeed()
    {
        return _config.Speed;
    }
}
