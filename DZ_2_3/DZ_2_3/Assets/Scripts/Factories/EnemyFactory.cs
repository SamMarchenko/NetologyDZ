using System;
using DefaultNamespace;
using UnityEngine;
using Random = System.Random;

public class EnemyFactory : MonoBehaviour
{
    private EnemyData _enemyView;
    private Random _random;

    private void Start()
    {
        _random = new Random();
    }

    public EnemyData CreateEnemy(UpdateManager updateManager)
    {
        var enemyRandomize = _random.Next(0, updateManager.EnemyTypes.Length);
        _enemyView = updateManager.EnemyTypes[enemyRandomize];
        var enemy = Instantiate(_enemyView);
        var enemyController = _enemyView.GetComponent<EnemyController>();
        enemyController.SetUpdateManager(updateManager);
        enemyController.EnemyData = _enemyView;
        updateManager.AddEnemy(enemy.GetComponent<EnemyData>());
        return enemy;
    }
}