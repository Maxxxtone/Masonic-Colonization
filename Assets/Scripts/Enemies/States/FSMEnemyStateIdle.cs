using UnityEngine;

public class FSMEnemyStateIdle : FSMState
{
    private float _timerToMove = 2f, _timer;
    public FSMEnemyStateIdle(FSM fSM) : base(fSM)
    {
    }
    public override void Enter()
    {
        _timer = _timerToMove;
    }
    public override void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            FSM.SetState<FSMEnemyStateMove>();
        }
    }
}
