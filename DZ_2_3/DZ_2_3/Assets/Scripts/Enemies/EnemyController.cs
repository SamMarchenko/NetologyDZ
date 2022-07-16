using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public UpdateManager _UpdateManager;
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
}