using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using StateStuff;

public class Patrol : State<AI> {

    private static Patrol _instance;
    private NavMeshAgent _agent;
    private Animator animator;

    private Patrol()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static Patrol instance
    {
        get
        {
            if (_instance == null)
            {
                new Patrol();
            }

            return _instance;
        }
    }

    public override void EnterState(AI _owner)
    {
        _agent = _owner.GetComponent<NavMeshAgent>();
        animator = _owner. GetComponent<Animator>();
        animator.SetInteger("animationCondition", 0);
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

    public void SetTarget(Transform target)
    {
        _agent.SetDestination(target.position);
    }

    public bool CheckPointReached()
    {
        if (_agent.remainingDistance < 0.5f)
        {
            return true;
        }
        return false;
    }
}
