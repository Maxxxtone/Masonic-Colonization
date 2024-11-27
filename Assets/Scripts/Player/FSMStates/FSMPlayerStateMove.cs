public class FSMPlayerStateMove : FSMState
{
    private Player _player;
    public FSMPlayerStateMove(FSM fSM, Player player) : base(fSM)
    {
        _player = player;
    }
    public override void Enter()
    {
        _player.Animator.SetBool("Move", true);
    }
    public override void Update()
    {
        _player.Movement.RotateBody(_player.InputHandler.MovementDirection);
        if(_player.InputHandler.MovementDirection.sqrMagnitude == 0)
            FSM.SetState<FSMPlayerStateIdle>();
    }
    public override void FixedUpdate()
    {
        _player.Movement.Move(_player.InputHandler.MovementDirection);
    }
    public override void Exit()
    {
        _player.Movement.StopMove();
        _player.Animator.SetBool("Move", false);
    }
}
