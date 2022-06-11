using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private Vector3 _destination;
    private NavMeshAgent _navMeshAgent;
    [SerializeField] GameObject _waypointsParentGO;
    [SerializeField] GameObject[] _waypointGOs;
    [SerializeField] int _numOfWaypoints;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        _waypointsParentGO = GameObject.Find("Waypoints");
        
        _numOfWaypoints = _waypointsParentGO.GetComponentInChildren<Transform>().childCount + 1;
        _waypointGOs = new GameObject[_numOfWaypoints];

        int i = 0;
        
        foreach (Transform wp in _waypointsParentGO.GetComponentsInChildren<Transform>())
        {
            _waypointGOs[i] = wp.GameObject();
            i++;
        }
        
        GetRandomWaypoint();
        
        _navMeshAgent.destination = _destination;
    }

    private void GetRandomWaypoint()
    {
        int rand = Random.Range(1, _numOfWaypoints);
        _destination = _waypointGOs[rand].transform.position;
    }
}
