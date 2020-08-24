using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public abstract class Enemy : MonoBehaviour, IEnemy
{
    protected int _enemyHP;
    public Enemy_SO enemy;
    public int EnemyHP { get => _enemyHP; set => _enemyHP = value; }
    public int EnemyMaxHP { get => enemy.enemyMaxHP;}
    public int EnemyDamage { get => enemy.enemyDamage;}

    public void Start()
    {
        _enemyHP = EnemyMaxHP;
    }

    public virtual void GiveDamage(PlayerCombat player) => player.TakeDamage(EnemyDamage);

    public virtual void TakeDamage(int damage)
    {
        if (_enemyHP > 0)
        {
            _enemyHP -= damage;
        }
        else
        {
            Destroy(this.gameObject, 0.1f);
        }
    }

}
