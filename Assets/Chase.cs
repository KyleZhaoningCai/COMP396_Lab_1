using UnityEngine;
using StateStuff;

public class Chase : State<AI>
{

    private static Chase _instance;

    private Chase()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static Chase instance
    {
        get
        {
            if (_instance == null)
            {
                new Chase();
            }

            return _instance;
        }
    }

    public override void EnterState(AI _owner)
    {
        Debug.Log("Entering Second State");
    }

    public override void ExitState(AI _owner)
    {
        Debug.Log("Exiting Second State");
    }

    public override void UpdateState(AI _owner)
    {
        if (!_owner.switchState)
        {
            _owner.stateMachine.ChangeState(Attack.instance);
        }
    }
}
