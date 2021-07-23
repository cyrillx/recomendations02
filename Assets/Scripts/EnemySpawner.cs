using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _cluster;
    [SerializeField] private GameObject _enemyTemplate;

    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_cluster.childCount];

        for (int i = 0; i < _cluster.childCount; i++)
        {
            _points[i] = _cluster.GetChild(i);
            Debug.Log("Child " + _cluster.GetChild(i));
            Debug.Log(_points[i].position.x);
        }
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Debug.Log("Dot " + _currentPoint);
            GameObject.Instantiate(_enemyTemplate, _points[_currentPoint].position, Quaternion.identity);
            _currentPoint++;
            if (_currentPoint == _points.Length)
                _currentPoint = 0;
            yield return new WaitForSeconds(2f);
        }
    }
}
