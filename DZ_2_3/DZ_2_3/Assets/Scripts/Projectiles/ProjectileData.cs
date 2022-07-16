using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;

public class ProjectileData : MonoBehaviour
{
    protected int Damage;
    protected float MoveSpeed;
    protected float _lifeTime;
    public float  LifeTime { get; set; }
    protected ProjectileType _projectileType;
    public ProjectileType ProjectileType => _projectileType;
}