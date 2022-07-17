using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerControl : BaseController
{
    
    [SerializeField] private UpdateManager _updateManager;

    //todo: перенести в playerData
    [SerializeField] float moveSpeed;
    [SerializeField] private float rateOfFire;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private PlayersData _playersData;
    public PlayersData PlayersData { get; set; }

    private float shootCoolDown;
    private void Start()
    {
        //_projectileType = ProjectileType.PlayersProjectile;
        shootCoolDown = rateOfFire;
    }
    void Update()
    {
        Moving();
        Shooting();
        PlayerRotate();
    }
    private void Moving()
    {
        var x = Input.GetAxis("Horizontal")*moveSpeed;
        var z = Input.GetAxis("Vertical")*moveSpeed;
        transform.Translate(x*Time.deltaTime, 0f, z*Time.deltaTime);
    }
    private void Shooting()
    {
        shootCoolDown -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && shootCoolDown < 0f)
        {
            
            Debug.Log("SHOOTING!!!");
            
            _updateManager.CreateBullet(_playersData);
            shootCoolDown = rateOfFire;
        }
    }
    private void PlayerRotate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0,-rotationSpeed,0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0,rotationSpeed,0);
        }
    }

    public void SetUpdateManager(UpdateManager updateManager)
    {
        _updateManager = updateManager;
    }
}
