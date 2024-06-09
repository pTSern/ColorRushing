using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [SerializeField] GameObject[] _waypoints;
    bool _isComplex;
    int _currentWaypointIndex = 0;
    Stats _stats;
    Direction _dir;
    enum Direction
    {
        FORWARD = 1,
        BACKWARD = -1
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _isComplex = false;
        if(GetComponent<Complex>())
        {
            _isComplex = GetComponent<Complex>().IsComplex();
        }
        _stats = GetComponent<Stats>();
        _dir = Direction.FORWARD;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, _waypoints[_currentWaypointIndex].transform.position) < 0.1f)
        {
            if(_isComplex)
            {
                _currentWaypointIndex = Random.Range(0, _waypoints.Length - 1);            
            }
            else
            {
                if (_currentWaypointIndex >= _waypoints.Length - 1) _dir = Direction.BACKWARD;
                else if (_currentWaypointIndex == 0) _dir = Direction.FORWARD;
                _currentWaypointIndex += (int)_dir * 1;

            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypointIndex].transform.position, _stats.getSpeed()*Time.deltaTime);
    }
}
