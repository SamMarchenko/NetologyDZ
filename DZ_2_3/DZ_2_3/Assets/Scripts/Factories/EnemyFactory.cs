using System;
using DefaultNamespace;
using UnityEngine;
using Random = System.Random;

public class EnemyFactory : MonoBehaviour
{
    //public UpdateManager _UpdateManager;
    private EnemyData _enemyView;
    //private EnemyData _enemyData;
    //private EnemyController _enemyController;
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
        enemyController._UpdateManager = updateManager;
        enemyController.EnemyData = _enemyView;
        updateManager.AddEnemy(enemy.GetComponent<EnemyData>());
        return enemy;
    }
}