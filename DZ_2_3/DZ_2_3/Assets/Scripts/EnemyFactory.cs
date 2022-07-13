using System;
using DefaultNamespace;
using UnityEngine;
using Random = System.Random;

public class EnemyFactory : MonoBehaviour
{
    public UpdateManager _UpdateManager;
    private GameObject _enemyView;
    private EnemyData _enemyData;
    private EnemyController _enemyController;
    private Random _random;

    private void Start()
    {
        _random = new Random();
    }

    public GameObject CreateEnemy()
    {
        var enemyRandomize = _random.Next(0, _UpdateManager.EnemyTypes.Length);
        _enemyView = _UpdateManager.EnemyTypes[enemyRandomize];
        var enemy = Instantiate(_enemyView);
        _UpdateManager.AddEnemy(enemy.GetComponent<EnemyData>());
        return enemy;
    }
}