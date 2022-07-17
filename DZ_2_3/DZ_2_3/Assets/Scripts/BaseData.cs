using DefaultNamespace;
using UnityEngine;

public class BaseData : MonoBehaviour
{
    
    
    protected int _health;
    protected float _rateOfFire;
    public float RateOfFire => _rateOfFire;
    protected float _moveSpeed;
    protected ProjectileType _projectileType;
    public ProjectileType ProjectileType => _projectileType;
    
}