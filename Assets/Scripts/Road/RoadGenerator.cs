using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _platform;
    [SerializeField] private GameObject _startPlatform;
    [SerializeField] private float _maxRoadCount;
    [SerializeField] private float _maxSpeed;

    private List<GameObject> _roads = new List<GameObject>();
    
    public float _speed = 0;

    private void Start()
    {
        ResetLevel();
        StarLevel();
    }

    private void Update()
    {
        if (_speed == 0)
            return;

        foreach (GameObject road in _roads)
        {
            road.transform.position -= new Vector3(0, 0, _speed * Time.deltaTime);
        }

        if (_roads[0].transform.position.z < -25)
        {
            Destroy(_roads[0]);
            _roads.RemoveAt(0);

            CreateNextRoad();
        }
    }

    public void StarLevel()
    {
        _speed = _maxSpeed;
    }

    private void CreateNextRoad()
    {
        Vector3 position = Vector3.zero;
        if (_roads.Count > 0)
            position = _roads[_roads.Count - 1].transform.position + new Vector3(0, 0, 20);

        GameObject spawned = Instantiate(_platform, position, Quaternion.identity);
        spawned.transform.SetParent(transform);
        _roads.Add(spawned);
    }

    private void ResetLevel()
    {
        _speed = 0;
        while (_roads.Count > 0)
        {
            Destroy(_roads[0]);
            _roads.RemoveAt(0);
        }
        for (int i = 0; i < _maxRoadCount; i++)
        {
            CreateNextRoad();
        }
    }

}