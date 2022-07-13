using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Random = System.Random;

public class UpdateManager : MonoBehaviour
{
    public PlayerControl _PlayerControl;
    public GameObject[] EnemyTypes;
    public GameObject[] ProjectileTypes;
    public Transform[] SpawnPoints;
    public List<EnemyData> _CreatedEnemies;
    public List<ProjectileData> _CreatedProjectiles;
    public List<Transform> FreeSpawnPoints;
    public EnemyFactory _EnemyFactory;
    private int minSpawnX = -20;
    private int maxSpawnX = 20;
    private int minSpawnZ = -20;
    private int maxSpawnZ = 20;
    private int counterOfEnemies = 0;
    public float CreationDelay = 3f;
    

    public void AddProjectile(ProjectileData projectileData)
    {
        _CreatedProjectiles.Add(projectileData);
    }

    public void RemoveProjectile(ProjectileData projectileData)
    {
        _CreatedProjectiles.Remove(projectileData);
    }

    

    public void CreateBullet(GameObject creator)
    {
    }

    private void Awake()
    {
        foreach (var spawnPoint in SpawnPoints)
        {
            AddFreeSpawnPoint(spawnPoint);
        }
    }

    private void Start()
    {
        CreateEnemy();
    }

    private void Update()
    {
        CreationDelayTick();
        while (counterOfEnemies < SpawnPoints.Length && CreationDelay <= 0)
        {
            CreateEnemy();
        }
    }

    private void CreationDelayTick()
    {
        if (CreationDelay <= 0) return;
        CreationDelay -= Time.deltaTime;
    }



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
        counterOfEnemies++;
        CreationDelay = 3f;
    }

    #endregion
}