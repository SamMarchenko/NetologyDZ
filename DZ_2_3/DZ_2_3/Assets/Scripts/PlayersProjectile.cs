using DefaultNamespace;

public class PlayersProjectile : ProjectileData
{
    public PlayersProjectile()
    {
        Damage = 1;
        MoveSpeed = 5;
        LifeTime = 15;
        _projectileType = ProjectileType.PlayersProjectile;
    }
}