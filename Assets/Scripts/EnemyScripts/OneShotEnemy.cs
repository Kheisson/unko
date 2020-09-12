using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotEnemy : MonoBehaviour
{
    public GameObject projectileGO;
    private Rigidbody2D _projectileRB;
    private Vector2 _playerPos;
    private Coroutine _shooting;
    private bool _canShoot = true;

    private void Update()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        // Firerate - if canShoot - canShoot should be false, Should Invoke the method with delay
        if (_playerPos != null && Vector2.Distance(transform.position,_playerPos) < 3  && _canShoot)
        {
            InitiateAttack(transform.position, _playerPos, 3);
        }
    }
    private void CanShootAgain() => _canShoot = true;

    public void InitiateAttack(Vector3 enemyLoc, Vector3 playerLoc, int attackSpeed)
    {
        GameObject projectile = Instantiate(projectileGO, enemyLoc, Quaternion.identity);
        _projectileRB = projectile.GetComponent<Rigidbody2D>();
        Vector2 direction = playerLoc - projectile.transform.position;
        direction.Normalize();
        projectile.transform.up = (playerLoc + projectile.transform.position);
        _projectileRB.velocity = direction * attackSpeed;
        _canShoot = false;
        Invoke("CanShootAgain", 1f); //Invoked with hardcoded value, should be dynamic.
    }

}


