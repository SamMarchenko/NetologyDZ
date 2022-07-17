using DefaultNamespace;
using UnityEngine;

public class BaseData : MonoBehaviour
{
    
    
    protected int _health;
    public int Health
    {
        get { return _health;}
        set { _health = value; }
    }
    protected float _rateOfFire;
    public float RateOfFire => _rateOfFire;
    protected float _moveSpeed;
    public float MoveSpeed => _moveSpeed;

    protected ProjectileType _projectileType;
    public ProjectileType ProjectileType => _projectileType;
    
    
}