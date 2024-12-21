using UnityEngine;

public class FSMEnemyStateMove : FSMState
{
    private EnemySystems _enemy;
    public FSMEnemyStateMove(FSM fSM, EnemySystems enemy) : base(fSM)
    {
        _enemy = enemy;
    }
    public override void Enter()
    {
        _enemy.EnemyMovement.Stopped += OnStopped;
        _enemy.EnemyMovement.SetRandomPosition();
    }
    public override void Exit()
    {
        _enemy.EnemyMovement.Stopped -= OnStopped;
    }
    private void OnStopped()
    {
        FSM.SetState<FSMEnemyStateIdle>();
    }
}
