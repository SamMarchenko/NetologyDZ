
using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public UpdateManager _UpdateManager;
    public EnemyData EnemyData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _UpdateManager.CreateBullet(EnemyData);
        }
    }
}
