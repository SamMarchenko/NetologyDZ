using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    protected int _health;
    protected float _attackSpeed;
    protected float _attackRange;
    protected float _moveSpeed;
    protected EnemyType _enemyType;
    protected ProjectileType _projectileType;
    public ProjectileType ProjectileType => _projectileType;
}