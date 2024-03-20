using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _repeatRate = 2f;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Vector2[] _spawnPoints;
    
    private Queue<Vector2> _spawnPointsQueue;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _spawnPointsQueue = new Queue<Vector2>(_spawnPoints);

        _pool = new ObjectPool<Enemy>(
            createFunc: () => CreateEnemy(),
            actionOnGet: (enemy) => ActionOnGet(enemy),
            actionOnRelease: (enemy) => enemy.gameObject.SetActive(false),
            actionOnDestroy: (enemy) => Destroy(enemy),
            collectionCheck: true,
            defaultCapacity: 10,
            maxSize: 20
            );
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void OnDisable()
    {
        _pool.Clear();
    }

    private void ActionOnGet(Enemy enemy)
    {
        enemy.transform.localPosition = GetSpawnPoint();
        enemy.gameObject.SetActive(true);
    }

    private Vector3 GetSpawnPoint()
    {
        var spawnPoint = _spawnPointsQueue.Dequeue();

        _spawnPointsQueue.Enqueue(spawnPoint);

        return spawnPoint;
    }

    private void Release(Enemy enemy)
    {
        _pool.Release(enemy);
    }

    private IEnumerator SpawnEnemies()
    {
        while (enabled)
        {
            if (_pool.CountActive < _spawnPoints.Length)
            {
                SpawnEnemy();
            }

            yield return new WaitForSeconds(_repeatRate);
        }
    }

    private Enemy CreateEnemy()
    {
        var enemy = Instantiate(_enemyPrefab, transform);

        enemy.transform.localPosition = GetSpawnPoint();
        enemy.OnEnemyDie += Release;

        return enemy;
    }

    private Enemy SpawnEnemy()
    {
        return _pool.Get();
    }
}