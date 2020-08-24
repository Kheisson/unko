using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    //Enemy interface
    int EnemyHP { get; set; }
    int EnemyMaxHP { get;}
    int EnemyDamage { get;}

    void TakeDamage(int damage);
    void GiveDamage(PlayerCombat player);


}
