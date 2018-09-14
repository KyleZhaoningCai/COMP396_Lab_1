using UnityEngine;
using StateStuff;

public class Attack : State<AI> {

    private static Attack _instance;

    private Attack()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static Attack instance
    {
        get
        {
            if (_instance == null)
            {
                new Attack();
            }

            return _instance;
        }
    }

    public override void EnterState(AI _owner)
    {
        Debug.Log("Entering First State");
    }

    public override void ExitState(AI _owner)
    {
        Debug.Log("Exiting First State");
    }

    public override void UpdateState(AI _owner)
    {
        if (_owner.switchState)
        {
            _owner.stateMachine.ChangeState(Chase.instance);
        }
    }
}
