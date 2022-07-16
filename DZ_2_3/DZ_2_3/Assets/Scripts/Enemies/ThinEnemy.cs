using DefaultNamespace;

public class ThinEnemy : EnemyData
{
    public ThinEnemy()
    {
        _health = 2;
        _rateOfFire = 4f;
        _attackRange = 10;
        _moveSpeed = 3;
        _enemyType = EnemyType.ThinEnemy;
        _projectileType = ProjectileType.FastProjectile;
    }
}