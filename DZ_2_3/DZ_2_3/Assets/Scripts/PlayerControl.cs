using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] private float rateOfFire;
    [SerializeField] private float rotationSpeed;
    protected ProjectileType _projectileType;
    public bool WantShoot;
    
    private float shootCoolDown;
    private void Start()
    {
        _projectileType = ProjectileType.PlayersProjectile;
        shootCoolDown = rateOfFire;
        WantShoot = false;
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
            WantShoot = true;
            //CreateBullet(transform.position);
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
}
