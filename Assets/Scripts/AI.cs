using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AI : MonoBehaviour
{
    private Vector3 _destination;
    private NavMeshAgent _navMeshAgent;
    [SerializeField] GameObject _waypointsParentGO;
    [SerializeField] GameObject[] _waypointGOs;
    [SerializeField] int _numOfWaypoints;
    [SerializeField] private bool _reachedLastWP = false;
    [SerializeField] private bool _reachedCurrentWP = false;
    private Vector3 _currentWPPosition;
    private int _currentWP;
    private int _lastWP;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        _waypointsParentGO = GameObject.Find("Waypoints");
        
        _numOfWaypoints = _waypointsParentGO.GetComponentInChildren<Transform>().childCount + 1;
        _lastWP = _numOfWaypoints - 1;
        _waypointGOs = new GameObject[_numOfWaypoints];

        int i = 0;
        foreach (Transform wp in _waypointsParentGO.GetComponentsInChildren<Transform>())
        {
            _waypointGOs[i] = wp.GameObject();
            i++;
        }
        
        //Move randomly
        //MoveAIRandomly();
        
        //Move as a path through waypoints
        _currentWP = 0;
    }

    private void Update()
    {
        if (_navMeshAgent.remainingDistance > 0.1f)
        {
            return;
        }
        else
        {
            _reachedCurrentWP = true;
            UpdateCurrentWP();
        }
        
        if (!_reachedLastWP && _reachedCurrentWP)
        {
            MoveToNextWaypoint();
            _reachedCurrentWP = false;
        }
    }

    private void UpdateCurrentWP()
    {
        if (_currentWP < _lastWP)
        {
            _currentWP += 1;
            _currentWPPosition = _waypointGOs[_currentWP].transform.position;
        }
        else
        {
            _reachedLastWP = true;
        }
    }

    private void MoveToNextWaypoint()
    {
        _navMeshAgent.destination = _currentWPPosition;
    }
    
    private void MoveAIRandomly()
    {
        GetRandomWaypoint();
        _navMeshAgent.destination = _destination;
    }
    
    private void GetRandomWaypoint()
    {
        int rand = Random.Range(1, _numOfWaypoints);
        _destination = _waypointGOs[rand].transform.position;
    }
}
