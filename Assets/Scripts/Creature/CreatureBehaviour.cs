using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatureBehaviour : MonoBehaviour
{
    private enum CreatureState
    {
        Patrolling,
        Chasing
    }

    private CreatureState CurrentState;

    public Transform[] PatrolPoints;

    private int CurrentPointIndext = 0;

    private NavMeshAgent Agent;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        CurrentState = CreatureState.Patrolling;
    }

    void Update()
    {
        float DistanceToPlayer = Vector3.Distance(transform.position, PatrolPoints[4].position);

        if (DistanceToPlayer <= 20)
        {
            CurrentState = CreatureState.Chasing;
        }
        else
        {
            CurrentState = CreatureState.Patrolling;
        }

        switch (CurrentState)
        {
            case CreatureState.Patrolling:

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

            case CreatureState.Chasing:

                Agent.destination = PatrolPoints[4].position;
                Agent.speed = 9;
                break;
        }

    }
}