using DefaultNamespace;

public class PlayersProjectile : ProjectileData
{
    public PlayersProjectile()
    {
        Damage = 1;
        _moveSpeed = 10;
        LifeTime = 5;
        _projectileType = ProjectileType.PlayersProjectile;
    }
}