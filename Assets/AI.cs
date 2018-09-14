using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using StateStuff;

public class AI : MonoBehaviour {

    public Transform[] points;
    public bool switchState;
    private int destPoint;
    public StateMachine<AI> stateMachine { get; set; }

    private void Start()
    {
        destPoint = 0;
        switchState = false;
        stateMachine = new StateMachine<AI>(this);
        stateMachine.ChangeState(Patrol.instance);
        Patrol.instance.SetTarget(points[destPoint]);

    }

    private void Update()
    {
        if (Patrol.instance.CheckPointReached())
        {
            destPoint = (destPoint + 1) % points.Length;
            Patrol.instance.SetTarget(points[destPoint]);
        }
        
        if (switchState)
        {
            stateMachine.Update();
        }
    }
}
