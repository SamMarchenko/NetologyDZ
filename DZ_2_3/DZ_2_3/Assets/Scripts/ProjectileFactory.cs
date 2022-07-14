using UnityEngine;

namespace DefaultNamespace
{
    public class ProjectileFactory : MonoBehaviour
    {
        public UpdateManager _UpdateManager;
        
        
        public ProjectileData CreateBullet(EnemyData enemyData)
        {
            var spawn = enemyData.transform.position;
            var projectileTypes = _UpdateManager.ProjectileTypes;
            foreach (var type in projectileTypes)
            {
                if (enemyData.ProjectileType == type.ProjectileType)
                {
                    var projectile = Instantiate(type, spawn, Quaternion.identity);
                    _UpdateManager.AddProjectile(projectile);
                    return projectile;
                }
            }
            return null;
        }
    }
}