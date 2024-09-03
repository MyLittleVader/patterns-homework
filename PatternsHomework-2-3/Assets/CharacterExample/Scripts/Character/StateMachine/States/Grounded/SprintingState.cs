public class SprintingState : MovingState
{
    private readonly SprintingStateConfig _config;

    public SprintingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.SprintingStateConfig;
    
    public override void Update()
    {
        base.Update();
        
        if (IsHorizontalInputZero())
        {
            StateSwitcher.SwitchState<IdlingState>();
            return;
        }
        if (WantsToWalk())
        {
            StateSwitcher.SwitchState<WalkingState>();
            return;
        }
        if (!WantsToSprint())
        {
            StateSwitcher.SwitchState<RunningState>();
            return;
        }
    }
    
    protected override void StartAnimation()
    {
        base.StartAnimation();
        
        View.StartSprinting();
    }

    protected override void StopAnimation()
    {
        base.StopAnimation();
        
        View.StopSprinting();
    }

    protected override float GetMovingSpeed()
    {
        return _config.Speed;
    }
}
