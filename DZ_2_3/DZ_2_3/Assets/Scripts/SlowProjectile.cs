using DefaultNamespace;

public class SlowProjectile : ProjectileData
{
    public SlowProjectile()
    {
        Damage = 5;
        MoveSpeed = 3;
        LifeTime = 20;
        _projectileType = ProjectileType.SlowProjectile;
    }
}