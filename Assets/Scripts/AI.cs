using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class AI : MonoBehaviour
{
    private enum AIState
    {
        Walking, Jumping, Attack, Death
    }

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
    [SerializeField] private AIState _currentAIState;
    
    
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
        CheckInput();

        if (!_navMeshAgent.isStopped)
        { WalkingOnPath(); }

        //PrintAIState();
    }

    private void CheckInput()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            _currentAIState = AIState.Jumping;
            if (_navMeshAgent.remainingDistance < 0.5f)
            {
                StartCoroutine(AttackingState());
            }
        }
    }

    private IEnumerator AttackingState()
    {
        Debug.Log("Performing the attack!");
        _currentAIState = AIState.Attack;
        _navMeshAgent.isStopped = true;
        yield return new WaitForSeconds(3f);
        _navMeshAgent.isStopped = false;
        _currentAIState = AIState.Walking;
    }

    private void WalkingOnPath()
    {
        if (_navMeshAgent.remainingDistance > 0.1f)
        { return; }
        else
        { _reachedCurrentWP = true; UpdateCurrentWP(); }
        
        if (!_reachedLastWP && _reachedCurrentWP)
        { MoveToNextWaypoint(); _reachedCurrentWP = false; }
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

    private void PrintAIState()
    {
        Debug.Log(_currentAIState);
    }
}
