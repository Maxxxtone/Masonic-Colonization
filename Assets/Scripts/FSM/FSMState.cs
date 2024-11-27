public abstract class FSMState
{
    protected readonly FSM FSM;
    public FSMState(FSM fSM) 
    { 
        FSM = fSM; 
    }
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
}
