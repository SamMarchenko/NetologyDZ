using DefaultNamespace;
using UnityEngine;

public class PlayersData : BaseData
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float moveSpeed;
    public float MoveSpeed => moveSpeed;

    public float RotationSpeed
    {
        get {return _rotationSpeed; }
        set { _rotationSpeed = value; }
    }
    public PlayersData()
    {
        //otationSpeed = 100f;
        _health = 10;
        _rateOfFire = 2f;
        //_moveSpeed = 30;
        _projectileType = ProjectileType.PlayersProjectile;
    }
}