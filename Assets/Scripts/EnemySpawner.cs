using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnCluster;
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private float _spawnDelay;

    private Transform[] _points;
    private int _currentPoint;
    private Coroutine _spawnCoroutine = null;

    public void StopSpawning()
    {
        StopCoroutine(_spawnCoroutine);
        _spawnCoroutine = null;
    }

    private void Start()
    {
        _points = new Transform[_spawnCluster.childCount];

        for (int i = 0; i < _spawnCluster.childCount; i++)
        {
            _points[i] = _spawnCluster.GetChild(i);
        }

        _spawnCoroutine = StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForSeconds = new WaitForSeconds(_spawnDelay);

        while (true)
        {
            GameObject.Instantiate(_enemyTemplate, _points[_currentPoint].position, Quaternion.identity);
            _currentPoint++;

            if (_currentPoint == _points.Length)
                _currentPoint = 0;

            yield return waitForSeconds;
        }
    }
}
