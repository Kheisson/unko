using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject projectileGO;
    private Rigidbody2D _projectileRB;


    public void InitiateAttack(Vector3 enemyLoc, Vector3 playerLoc, int attackSpeed)
    {
        GameObject projectile = Instantiate(projectileGO, enemyLoc, Quaternion.identity);
        _projectileRB = projectile.GetComponent<Rigidbody2D>();
        Vector2 direction = playerLoc - projectile.transform.position;
        direction.Normalize();
        _projectileRB.velocity = direction * attackSpeed;
    }
}
