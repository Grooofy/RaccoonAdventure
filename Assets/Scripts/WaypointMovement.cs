using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private List<Transform> _points;
    private int _currentPoint = 0;

    private void Start() => GetPath();

    private void Update() =>  Move();
   
    private void Move()
    {
        Transform target = _points[_currentPoint];
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        
        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint == _points.Count)
                _currentPoint = 0;
        }
    }

    private void GetPath()
    {
        _points = new List<Transform>();

        for (int i = 0; i < _path.childCount; i++) 
            _points.Add(_path.GetChild(i));
    }
}
