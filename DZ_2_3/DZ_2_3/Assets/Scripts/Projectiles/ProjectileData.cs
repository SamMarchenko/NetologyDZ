using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;

public class ProjectileData : MonoBehaviour
{
    protected int _damage;
    public int Damage => _damage;
    protected float _moveSpeed;
    public float MoveSpeed => _moveSpeed;

    public bool CanDestroy;

    protected float _lifeTime;

    public float LifeTime
    {
        get 
    {
        return _lifeTime;
    }
        set
        {
            _lifeTime = value ;
        }
    }
    protected ProjectileType _projectileType;
    public ProjectileType ProjectileType => _projectileType;
    
    private void OnCollisionEnter(Collision other)
    {
        if (gameObject.CompareTag("PlayersProjectile")&& other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy HURTS!");
           var enemyData = other.gameObject.GetComponent<EnemyData>();
           var projectileData = gameObject.GetComponent<ProjectileData>();
           enemyData.Health -= projectileData._damage;
           CanDestroy = true;
           Debug.Log($"Enemies health = {enemyData.Health}");
        }

        if (gameObject.CompareTag("EnemiesProjectile")&& other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player HURTS");
            var playerData = other.gameObject.GetComponent<PlayersData>();
            var projectileData = gameObject.GetComponent<ProjectileData>();
            playerData.Health -= projectileData._damage;
            CanDestroy = true;
            Debug.Log($"Players health = {playerData.Health}");
        }
    }
}