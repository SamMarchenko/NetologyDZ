using DefaultNamespace;

public class FastProjectile : ProjectileData
{
    public FastProjectile()
    {
        Damage = 1;
        _moveSpeed = 7;
        LifeTime = 15;
        _projectileType = ProjectileType.FastProjectile;
    }
}