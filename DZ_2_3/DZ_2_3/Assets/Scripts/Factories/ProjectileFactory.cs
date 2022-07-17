using UnityEngine;

namespace DefaultNamespace
{
    public class ProjectileFactory : MonoBehaviour
    {
        public UpdateManager _UpdateManager;
        
        
        public ProjectileData CreateBullet(BaseData enemyData)
        {
            var spawn = enemyData.transform.TransformPoint(Vector3.forward*1.1f);
            var projectileTypes = _UpdateManager.ProjectileTypes;
            foreach (var type in projectileTypes)
            {
                if (enemyData.ProjectileType == type.ProjectileType)
                {
                    var projectile = Instantiate(type, spawn, Quaternion.identity);
                    projectile.transform.rotation = enemyData.transform.rotation;
                    _UpdateManager.AddProjectile(projectile);
                    return projectile;
                }
            }
            return null;
        }
    }
}