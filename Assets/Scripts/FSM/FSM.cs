using System;
using System.Collections.Generic;
using System.Linq;

public class FSM 
{
    private Dictionary<Type, FSMState> _states = new Dictionary<Type, FSMState>();
    private FSMState _currentState;
    public FSMState CurrentState => _currentState;
    public void AddState(FSMState state)
    {
       _states.Add(state.GetType(), state);
    }
    public void AddState(Type type, FSMState state)
    {
        _states.Add(type, state);
    }
    public void SetState<T>() where T : FSMState
    {
        if (_currentState != null && _currentState.GetType() == typeof(T)) return;
        if(_states.TryGetValue(typeof(T), out var newState))
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
    }
    public void Update()
    {
        _currentState?.Update();
    }
    public void FixedUpdate()
    {
        _currentState?.FixedUpdate();
    }
}
