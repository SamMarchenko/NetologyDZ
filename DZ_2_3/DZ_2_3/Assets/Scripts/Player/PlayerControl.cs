using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerControl : BaseController
{
    [SerializeField] private UpdateManager _updateManager;
    [SerializeField] private PlayersData _playersData;
    public PlayersData PlayersData { get; set; }

    private float shootCoolDown;

    private void Start()
    {
        shootCoolDown = _playersData.RateOfFire;
    }

    void Update()
    {
        Moving();
        Shooting();
        PlayerRotate();
    }

    private void Moving()
    {
        var x = Input.GetAxis("Horizontal") * _playersData.MoveSpeed;
        var z = Input.GetAxis("Vertical") * _playersData.MoveSpeed;
        transform.Translate(x * Time.deltaTime, 0f, z * Time.deltaTime);
    }

    private void Shooting()
    {
        shootCoolDown -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && shootCoolDown < 0f)
        {
            Debug.Log("SHOOTING!!!");

            _updateManager.CreateBullet(_playersData);
            shootCoolDown = _playersData.RateOfFire;
        }
    }

    private void PlayerRotate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -_playersData.RotationSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, _playersData.RotationSpeed *Time.fixedDeltaTime, 0);
        }
    }

    public void SetUpdateManager(UpdateManager updateManager)
    {
        _updateManager = updateManager;
    }
}