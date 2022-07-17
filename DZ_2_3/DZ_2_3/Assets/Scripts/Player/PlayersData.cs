using DefaultNamespace;
using UnityEngine;

public class PlayersData : BaseData
{
    [SerializeField] private float _rotationSpeed;
    public float RotationSpeed
    {
        get {return _rotationSpeed; }
        set { _rotationSpeed = value; }
    }
    public PlayersData()
    {
        RotationSpeed = 10000f;
        _health = 10;
        _rateOfFire = 4f;
        _moveSpeed = 30;
        _projectileType = ProjectileType.PlayersProjectile;
    }
}