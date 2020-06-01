using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentRandomMove : MonoBehaviour
{
    [SerializeField] private float _walkRadius = 10f;
    private NavMeshAgent _navMeshAgent;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.autoBraking = false;
        _navMeshAgent.speed = 1f;

        SetNewPath();
    }

    private void SetNewPath()
    {
        Vector3 randomDirection = Random.insideUnitSphere * _walkRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, _walkRadius, 1);
        Vector3 finalPosition = hit.position;
        _navMeshAgent.SetDestination(finalPosition);
    }

    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (_navMeshAgent.enabled && !_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.5f)
            SetNewPath();
    }
}
