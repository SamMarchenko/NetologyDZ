using DefaultNamespace;

public class SlowProjectile : ProjectileData
{
    public SlowProjectile()
    {
        Damage = 5;
        _moveSpeed = 3;
        LifeTime = 20;
        _projectileType = ProjectileType.SlowProjectile;
    }
}