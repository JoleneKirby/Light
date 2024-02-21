using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatureBehaviour : MonoBehaviour
{
    private enum CreatureStates
    {
        Patrolling,
        Chasing
    }

    private CreatureStates CurrentState;

    public Transform[] PatrolPoints;

    private int CurrentPointIndext = 0;

    private NavMeshAgent Agent;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float DistanceToPlayer = Vector3.Distance(transform.position, PatrolPoints[PatrolPoints.Length - 1].position);

        if (DistanceToPlayer <= 20)
        {
            CurrentState = CreatureStates.Chasing;
        }
        else
        {
            CurrentState = CreatureStates.Patrolling;
        }

        switch (CurrentState)
        {
            case CreatureStates.Patrolling:

                Agent.SetDestination(PatrolPoints[CurrentPointIndext].position);

                if (Agent.remainingDistance <= 0.1f)
                {
                    CurrentPointIndext += 1;
                    
                    if (CurrentPointIndext >= PatrolPoints.Length - 1)
                    {
                        CurrentPointIndext = 0;
                    }
                }

                Agent.speed = 5;
                break;

            case CreatureStates.Chasing:

                Agent.SetDestination(PatrolPoints[PatrolPoints.Length - 1].position);
                Agent.speed = 9;
                break;
        }

    }
}