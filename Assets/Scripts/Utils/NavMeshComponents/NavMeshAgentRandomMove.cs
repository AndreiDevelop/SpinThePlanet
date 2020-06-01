using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentRandomMove : MonoBehaviour
{
    [SerializeField] private float _walkRadius = 10f;
    [SerializeField] private float _timeToChangePathInSeconds = 5f;

    private NavMeshAgent _navMeshAgent;
    private Coroutine _pathUpdate;
    
    private Coroutine _timeChangePath;   
    private bool _isTimeToChangePath = false;

    private float _pathUpdateInSeconds = 0.1f;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.autoBraking = false;
        _navMeshAgent.speed = 1f;
    }

    private void OnEnable()
    {
        StopPathUpdate();

        _pathUpdate = StartCoroutine(PathUpdate());
    }

    private void OnDisable()
    {
        StopPathUpdate();
    }

    private void SetNewPath()
    {
        if(_navMeshAgent.enabled)
        {
            Vector3 randomDirection = Random.insideUnitSphere * _walkRadius;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, _walkRadius, 1);
            Vector3 finalPosition = hit.position;
            _navMeshAgent.SetDestination(finalPosition);
        }       
    }

    private IEnumerator PathUpdate()
    {
        while(true)
        {
            yield return new WaitForSeconds(_pathUpdateInSeconds);

            if (_isTimeToChangePath ||(_navMeshAgent.enabled && !_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.5f))
            {
                StopTimeChangePath();
                SetNewPath();
            }           
            else if (_timeChangePath == null)
            {
                StopTimeChangePath();
                _timeChangePath = StartCoroutine(TimeChangePathUpdate());
            }
        }       
    }

    private void StopPathUpdate()
    {
        if (_pathUpdate != null)
        {
            StopCoroutine(_pathUpdate);
        }
        StopTimeChangePath();
    }

    private IEnumerator TimeChangePathUpdate()
    {
        _isTimeToChangePath = false;
        yield return new WaitForSeconds(_timeToChangePathInSeconds);
        _isTimeToChangePath = true;
    }

    private void StopTimeChangePath()
    {
        if(_timeChangePath !=null)
        {
            StopCoroutine(_timeChangePath);
            _isTimeToChangePath = false;
        }

        _timeChangePath = null;
    }
}
