using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damageToInflict;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerCombat>().TakeDamage(damageToInflict);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
