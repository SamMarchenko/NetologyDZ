using DefaultNamespace;

public class SlowProjectile : ProjectileData
{
    public SlowProjectile()
    {
        _damage = 3;
        _moveSpeed = 3;
        LifeTime = 20;
        _projectileType = ProjectileType.SlowProjectile;
    }
}