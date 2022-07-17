using DefaultNamespace;

public struct ProjectileData
{
    private int _damage;
    public int Damage => _damage;
    private float _moveSpeed;
    public float MoveSpeed => _moveSpeed;
    
    private float _lifeTime;
    public float LifeTime
    {
        get 
        {
            return _lifeTime;
        }
        set
        {
            _lifeTime = value ;
        }
    }
    private ProjectileType _projectileType;
    public ProjectileType ProjectileType => _projectileType;

    public ProjectileData(int damage, float moveSpeed, float lifeTime, ProjectileType projectileType)
    {
        _damage = damage;
        _moveSpeed = moveSpeed;
        _lifeTime = lifeTime;
        _projectileType = projectileType;
    }
}