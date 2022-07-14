using System;
using DefaultNamespace;
using UnityEngine;
using Random = System.Random;

public class EnemyFactory : MonoBehaviour
{
    public UpdateManager _UpdateManager;
    private EnemyData _enemyView;
    private EnemyData _enemyData;
    private EnemyController _enemyController;
    private Random _random;

    private void Start()
    {
        _random = new Random();
    }

    public EnemyData CreateEnemy()
    {
        var enemyRandomize = _random.Next(0, _UpdateManager.EnemyTypes.Length);
        _enemyView = _UpdateManager.EnemyTypes[enemyRandomize];
        var enemy = Instantiate(_enemyView);
        var enemyController = _enemyView.GetComponent<EnemyController>();
        enemyController._UpdateManager = _UpdateManager;
        enemyController.EnemyData = _enemyView;
        _UpdateManager.AddEnemy(enemy.GetComponent<EnemyData>());
        return enemy;
    }
}