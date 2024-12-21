using UnityEngine;

[RequireComponent(typeof(EnemyMovement), typeof(EnemyHealth))]
public class EnemySystems : MonoBehaviour
{
    private FSM _fsm;
    private EnemyMovement _enemyMovement;
    private EnemyHealth _enemyHealth;
    public EnemyMovement EnemyMovement => _enemyMovement;
    private void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _fsm = new FSM();
        _fsm.AddState(new FSMEnemyStateIdle(_fsm));
        _fsm.AddState(new FSMEnemyStateMove(_fsm, this));
        _fsm.SetState<FSMEnemyStateIdle>();
    }
    private void Update()
    {
        _fsm.Update();
    }
    private void FixedUpdate()
    {
        _fsm.FixedUpdate();
    }
}
