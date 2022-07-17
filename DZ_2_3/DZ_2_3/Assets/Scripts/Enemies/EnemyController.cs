using System;
using UnityEngine;

public class EnemyController : BaseController
{
    //todo: Сделать серилизованным
    [SerializeField] private UpdateManager _UpdateManager;
    public SpawnPointController SpawnPointController;
    public UpdateManager UpdateManager => _UpdateManager;
    public EnemyData EnemyData;
    public GameObject enemy;
    private float _shootCoolDown;

    public void Start()
    {
        _shootCoolDown = EnemyData.RateOfFire;
    }

    public void Update()
    {
        _shootCoolDown -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && _shootCoolDown < 0f)
        {
            enemy.transform.LookAt(other.transform);
            _UpdateManager.CreateBullet(EnemyData);
            _shootCoolDown = EnemyData.RateOfFire;
        }
    }

    public void SetUpdateManager(UpdateManager updateManager)
    {
        _UpdateManager = updateManager;
        if (_UpdateManager == null)
        {
            Debug.Log($"{gameObject.name} IS NULL!!!");
        }
    }
}