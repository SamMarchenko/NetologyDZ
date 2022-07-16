using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using Random = System.Random;

public class UpdateManager : MonoBehaviour
{
    public PlayerControl _PlayerControl;
    public EnemyData[] EnemyTypes;
    public ProjectileData[] ProjectileTypes;
    public Transform[] SpawnPoints;
    public List<EnemyData> _CreatedEnemies;
    public List<ProjectileData> _CreatedProjectiles;
    public List<Transform> FreeSpawnPoints;
    public EnemyFactory _EnemyFactory;
    public ProjectileFactory _ProjectileFactory;
    public float CreationDelay = 3f;
    
    private void Awake()
    {
        var endedProjectiles = new List<ProjectileData>();
        foreach (var spawnPoint in SpawnPoints)
        {
            AddFreeSpawnPoint(spawnPoint);
        }
    }

    private void Update()
    {
        CreationDelayTick();
        while (FreeSpawnPoints.Count > 0 && CreationDelay <= 0)
        {
            CreateEnemy();
        }

        if (_CreatedProjectiles.Count > 0)
        {
            UpdateMovingProjectiles();
            UpdateLifeTimeOfProjectiles();
            ClearEndedProjectiles();
        }
    }

    private void CreationDelayTick()
    {
        if (CreationDelay <= 0) return;
        CreationDelay -= Time.deltaTime;
    }
    public void CreateBullet(BaseData creator)
    {
        _ProjectileFactory.CreateBullet(creator);
    }

    #region Projectile

    public void AddProjectile(ProjectileData projectileData)
    {
        _CreatedProjectiles.Add(projectileData);
    }

    public void RemoveAndDeleteProjectile(ProjectileData projectileData)
    {
        _CreatedProjectiles.Remove(projectileData);
        Destroy(projectileData.gameObject);
    }
    public void ClearEndedProjectiles()
    {
        for (int i = 0; i < _CreatedProjectiles.Count; i++)
        {
            if (_CreatedProjectiles[i].LifeTime <=0)
            {
                RemoveAndDeleteProjectile(_CreatedProjectiles[i]);
            }
        }  
    }
    public void RemoveProjectiles(List<ProjectileData> projectiles)
    {
        for (int i = 0; i < _CreatedProjectiles.Count; i++)
        {
            RemoveAndDeleteProjectile(_CreatedProjectiles[i]);
        }
    }

    public void UpdateLifeTimeOfProjectiles()
    {
        foreach (var projectile in _CreatedProjectiles)
        {
            projectile.LifeTime -= Time.deltaTime;
        }
    }
    public void UpdateMovingProjectiles()
    {
        foreach (var projectile in _CreatedProjectiles)
        {
            projectile.transform.Translate(0,0,projectile.MoveSpeed * Time.deltaTime);
        }
    }
    public List<ProjectileData> GettAllEndedProjectiles()
    {
        var EndedLifeTimeProjectiles = new List<ProjectileData>();
        foreach (var projectile in _CreatedProjectiles)
        {
            if (projectile.LifeTime > 0) continue;
            EndedLifeTimeProjectiles.Add(projectile);
        }

        return EndedLifeTimeProjectiles;
    }

    #endregion

    #region SpawnPoints

    public void AddFreeSpawnPoint(Transform spawnPoint)
    {
        FreeSpawnPoints.Add(spawnPoint);
    }

    public void RemoveSpawnPoint(Transform spawnPoint)
    {
        FreeSpawnPoints.Remove(spawnPoint);
    }

    public Transform GiveRandomFreeSpawnPoint()
    {
        Random random = new Random();
        var spawnPoint = FreeSpawnPoints[random.Next(0, FreeSpawnPoints.Count)];
        RemoveSpawnPoint(spawnPoint);
        return spawnPoint;
    }

    #endregion

    #region Enemy

    public void AddEnemy(EnemyData enemyData)
    {
        _CreatedEnemies.Add(enemyData);
    }

    public void RemoveEnemy(EnemyData enemyData)
    {
        _CreatedEnemies.Remove(enemyData);
    }

    private void CreateEnemy()
    {
        var enemy = _EnemyFactory.CreateEnemy();
        enemy.transform.position = GiveRandomFreeSpawnPoint().position;
        CreationDelay = 3f;
    }

    #endregion
}