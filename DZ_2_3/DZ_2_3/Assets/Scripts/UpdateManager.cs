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
    public PlayersData Player;
    public ProjectileController[] ProjectileTypes;
    public Transform[] SpawnPoints;
    public List<BaseData> _CreatedUnits;
    public List<ProjectileController> _CreatedProjectiles;
    public List<Transform> FreeSpawnPoints;
    public List<SpawnPointController> OccupiedSpawnPoints;
    public EnemyFactory _EnemyFactory;
    public ProjectileFactory _ProjectileFactory;
    public PlayersFactory _PlayersFactory;
    public float CreationDelay = 1.5f;

    private void Awake()
    {
        var endedProjectiles = new List<ProjectileController>();
        foreach (var spawnPoint in SpawnPoints)
        {
            AddFreeSpawnPoint(spawnPoint);
        }
    }

    private void Start()
    {
        _PlayersFactory.CreatePlayer(this);
    }


    private void Update()
    {
        CreationDelayTick();
        while (FreeSpawnPoints.Count > 0 && CreationDelay <= 0)
        {
            CreateEnemy();
        }

        if (_CreatedUnits.Count > 0)
        {
            CheckUnitsHealth();
            
        }
        CheckIsFreePointAndUpdate();

        if (_CreatedProjectiles.Count > 0)
        {
            UpdateMovingProjectiles();
            UpdateLifeTimeOfProjectiles();
            CheckCanDestroyProjectiles();
            ClearEndedProjectiles();
        }
    }
    
    public void CreateBullet(BaseData creator)
    {
        _ProjectileFactory.CreateBullet(creator);
    }

    #region Projectile

    public void AddProjectile(ProjectileController projectileController)
    {
        _CreatedProjectiles.Add(projectileController);
    }

    public void RemoveAndDeleteProjectile(ProjectileController projectileController)
    {
        _CreatedProjectiles.Remove(projectileController);
        Destroy(projectileController.gameObject);
    }

    public void ClearEndedProjectiles()
    {
        for (int i = 0; i < _CreatedProjectiles.Count; i++)
        {
            if (_CreatedProjectiles[i].projectileData.LifeTime <= 0)
            {
                RemoveAndDeleteProjectile(_CreatedProjectiles[i]);
            }
        }
    }

    public void UpdateLifeTimeOfProjectiles()
    {
        foreach (var projectile in _CreatedProjectiles)
        {
            projectile.projectileData.LifeTime -= Time.deltaTime;
        }
    }

    public void CheckCanDestroyProjectiles()
    {
        for (int i = 0; i < _CreatedProjectiles.Count; i++)
        {
            if (_CreatedProjectiles[i].CanDestroy)
            {
                RemoveAndDeleteProjectile(_CreatedProjectiles[i]);
            }
        }
    }

    public void UpdateMovingProjectiles()
    {
        foreach (var projectile in _CreatedProjectiles)
        {
            projectile.transform.Translate(0, 0, projectile.projectileData.MoveSpeed * Time.deltaTime);
        }
    }

    #endregion

    #region SpawnPoints

    public void CheckIsFreePointAndUpdate()
    {
        for (int i = 0; i < OccupiedSpawnPoints.Count; i++)
        {
            if (OccupiedSpawnPoints[i].CreatedObject is null)
            {
                AddFreeSpawnPoint(OccupiedSpawnPoints[i].transform);
                CreationDelay = 1.5f;
            }
        }
    }
    public void AddFreeSpawnPoint(Transform spawnPoint)
    {
        FreeSpawnPoints.Add(spawnPoint);
        OccupiedSpawnPoints.Remove(spawnPoint.GetComponent<SpawnPointController>());
    }

    public void RemoveSpawnPoint(Transform spawnPoint)
    {
        FreeSpawnPoints.Remove(spawnPoint);
        OccupiedSpawnPoints.Add(spawnPoint.GetComponent<SpawnPointController>());
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
    
    private void CreationDelayTick()
    {
        if (CreationDelay <= 0) return;
        CreationDelay -= Time.deltaTime;
    }
    
    public void AddEnemy(EnemyData enemyData)
    {
        _CreatedUnits.Add(enemyData);
        if (enemyData.EnemyController is null)
        {
            Debug.Log("EnemyController is Null!");
        }

        if (enemyData.EnemyController.UpdateManager is null)
        {
            enemyData.EnemyController.SetUpdateManager(this);
        }
    }

    public void AddPlayer(PlayersData playerData)
    {
        _CreatedUnits.Add(playerData);
    }

    public void RemoveEnemyAndClearList(BaseData enemyData)
    {
        _CreatedUnits.Remove(enemyData);
        var enemyController = enemyData.GetComponent<EnemyController>();
        if (enemyData as EnemyData)
        {
            enemyController.SpawnPointController.CreatedObject = null;
        }
        Destroy(enemyData.gameObject);
    }

    private void CreateEnemy()
    {
        var enemy = _EnemyFactory.CreateEnemy(this);
        
        var spawnPoint = GiveRandomFreeSpawnPoint();
        enemy.transform.position = spawnPoint.position;
        var spawnPointController = spawnPoint.GetComponent<SpawnPointController>();
        spawnPointController.CreatedObject = enemy.gameObject;
        enemy.EnemyController.SpawnPointController = spawnPointController;
        CreationDelay = 1.5f;
    }

    public void CheckUnitsHealth()
    {
        for (int i = 0; i < _CreatedUnits.Count; i++)
        {
            if (_CreatedUnits[i].Health <= 0)
            {
                RemoveEnemyAndClearList(_CreatedUnits[i]);
            }
        }
    }

    #endregion
}