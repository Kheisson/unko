using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    //Enemy interface
    int EnemyHP { get; set; }
    int EnemyMaxHP { get; set; }
    int EnemyDamage { get; set; }

    void TakeDamage(int damage);
    void GiveDamage(int damage);


}
