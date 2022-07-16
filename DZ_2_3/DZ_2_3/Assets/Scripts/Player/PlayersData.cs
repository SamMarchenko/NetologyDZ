using DefaultNamespace;

public class PlayersData : BaseData
{
    public PlayersData()
    {
        _health = 2;
        _rateOfFire = 4f;
        _moveSpeed = 3;
        _projectileType = ProjectileType.PlayersProjectile;
    }
}