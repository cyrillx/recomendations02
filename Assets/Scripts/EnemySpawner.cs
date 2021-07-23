using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnCluster;
    [SerializeField] private GameObject _enemyTemplate;

    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_spawnCluster.childCount];

        for (int i = 0; i < _spawnCluster.childCount; i++)
        {
            _points[i] = _spawnCluster.GetChild(i);
        }
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject.Instantiate(_enemyTemplate, _points[_currentPoint].position, Quaternion.identity);
            _currentPoint++;
            if (_currentPoint == _points.Length)
                _currentPoint = 0;
            yield return new WaitForSeconds(2f);
        }
    }
}
