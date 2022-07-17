using DefaultNamespace;

public class PlayersProjectile : ProjectileData
{
    public PlayersProjectile()
    {
        _damage = 5;
        _moveSpeed = 15;
        LifeTime = 5;
        _projectileType = ProjectileType.PlayersProjectile;
    }
    
}