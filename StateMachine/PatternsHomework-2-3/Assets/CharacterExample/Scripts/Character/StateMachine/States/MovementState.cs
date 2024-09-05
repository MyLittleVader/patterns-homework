using UnityEngine;

public abstract class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;
    private readonly Character _character;

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _character = character;
    }

    protected PlayerInput Input => _character.Input;
    protected CharacterController CharacterController => _character.Controller;
    protected CharacterView View => _character.View;
    
    // Changed new Quaternion(0, 0, 0, 0) to Quaternion.identity
    private Quaternion TurnRight => Quaternion.identity;
    private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

    public virtual void Enter()
    {
        Debug.Log(GetType());
    }

    public virtual void Exit()
    {
    }

    public void HandleInput()
    {
        Data.WantsToSprint = Input.Movement.Sprint.inProgress;
        Data.WantsToWalk = Input.Movement.Walking.inProgress;
        
        Data.XInput = ReadHorizontalInput();
        Data.XVelocity = Data.XInput * Data.Speed;
    }

    public virtual void Update()
    {
        Vector3 velocity = GetConvertedVelocity();

        CharacterController.Move(velocity * Time.deltaTime);
        _character.transform.rotation = GetRotationFrom(velocity);
    }

    protected bool IsHorizontalInputZero() => Data.XInput == 0;
    protected bool WantsToWalk() => Data.WantsToWalk && !Data.WantsToSprint;
    // We will give priority to sprinting in situations where player holds both buttons for walking and sprinting
    protected bool WantsToSprint() => Data.WantsToSprint;

    private Quaternion GetRotationFrom(Vector3 velocity)
    {
        if (velocity.x > 0)
            return TurnRight;

        if (velocity.x < 0)
            return TurnLeft;

        return _character.transform.rotation;
    }

    private Vector3 GetConvertedVelocity() => new Vector3(Data.XVelocity, Data.YVelocity, 0);

    private float ReadHorizontalInput() => Input.Movement.Move.ReadValue<float>();
}
