﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Enemy _enemy;
    private PlayerCombat _player;

    private void Start()
    {
        
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy") && collision != null)
        {
            _enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
            _enemy.TakeDamage(_player.playerDamage);
            Destroy(gameObject);
        }
    }
}