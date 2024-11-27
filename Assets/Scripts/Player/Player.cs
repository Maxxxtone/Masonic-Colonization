using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerMovement), typeof(InputHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerWeaponHolder _weaponHolder;
    private PlayerMovement _movement;
    private Animator _animator;
    private InputHandler _inputHandler;
    private FSM _fsm;
    public PlayerMovement Movement => _movement;
    public Animator Animator => _animator;
    public InputHandler InputHandler => _inputHandler;
    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
        _inputHandler = GetComponent<InputHandler>();

        _inputHandler.AttackButtonTriggered += _weaponHolder.MeleeAttack;

        _fsm = new FSM();
        _fsm.AddState(new FSMPlayerStateIdle(_fsm, this));
        _fsm.AddState(new FSMPlayerStateMove(_fsm, this));
        _fsm.SetState<FSMPlayerStateIdle>();
    }
    private void Update()
    {
        _fsm.Update();
    }
    private void FixedUpdate()
    {
        _fsm.FixedUpdate();
    }
    private void OnDisable()
    {
        _inputHandler.AttackButtonTriggered -= _weaponHolder.MeleeAttack;
    }
}
