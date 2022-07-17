using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EnemyData : BaseData
{
    [SerializeField] private EnemyController _enemyController;
    public EnemyController EnemyController => _enemyController;
    
    protected float _attackRange;
    protected EnemyType _enemyType;
}