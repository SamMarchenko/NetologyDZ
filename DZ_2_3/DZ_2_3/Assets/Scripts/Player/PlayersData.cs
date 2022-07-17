using DefaultNamespace;

public class PlayersData : BaseData
{
    public PlayersData()
    {
        _health = 10;
        _rateOfFire = 4f;
        _moveSpeed = 3;
        _projectileType = ProjectileType.PlayersProjectile;
    }
}