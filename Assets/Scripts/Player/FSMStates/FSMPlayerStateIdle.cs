using UnityEngine;

public class FSMPlayerStateIdle : FSMState
{
    private Player _player;
    public FSMPlayerStateIdle(FSM fSM, Player player) : base(fSM)
    {
        _player = player;
    }
    public override void Update()
    {
        if (_player.InputHandler.MovementDirection.magnitude > 0)
        {
            FSM.SetState<FSMPlayerStateMove>();
        }
    }
}
