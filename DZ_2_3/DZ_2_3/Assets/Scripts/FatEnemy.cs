using DefaultNamespace;

public class FatEnemy : EnemyData
{
    public FatEnemy()
    {
        _health = 5;
        _attackSpeed = 2f;
        _attackRange = 5;
        _moveSpeed = 1;
        _enemyType = EnemyType.FatEnemy;
        _projectileType = ProjectileType.SlowProjectile;
    }
}