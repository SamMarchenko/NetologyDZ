using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;

public class ProjectileController : MonoBehaviour
{

    public ProjectileData projectileData;
    public bool CanDestroy;

    [SerializeField] private ProjectileType _projectileType;
    public ProjectileType ProjectileType => _projectileType;

    private void Start()
    {
        switch (ProjectileType)
        {
            case ProjectileType.SlowProjectile:
               projectileData = new ProjectileData(3, 3, 20, ProjectileType.SlowProjectile);
                break;
            case ProjectileType.FastProjectile:
                projectileData = new ProjectileData(1, 7, 15, ProjectileType.FastProjectile);
                break;
            case ProjectileType.PlayersProjectile:
                projectileData = new ProjectileData(5, 15, 5, ProjectileType.PlayersProjectile);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (gameObject.CompareTag("PlayersProjectile")&& other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy HURTS!");
           var enemyData = other.gameObject.GetComponent<EnemyData>();
           var projectileData = gameObject.GetComponent<ProjectileController>();
           enemyData.Health -= this.projectileData.Damage;
           CanDestroy = true;
           Debug.Log($"Enemies health = {enemyData.Health}");
        }

        if (gameObject.CompareTag("EnemiesProjectile")&& other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player HURTS");
            var playerData = other.gameObject.GetComponent<PlayersData>();
            var projectileData = gameObject.GetComponent<ProjectileController>();
            playerData.Health -= this.projectileData.Damage;
            CanDestroy = true;
            Debug.Log($"Players health = {playerData.Health}");
        }
    }
}