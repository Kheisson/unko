using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItemSpawn : MonoBehaviour
{
    public GameObject coin;
    public GameObject healthPotion;

    private float _chanceOfSpawning = 0.6f;

    //Spawn an Item when enemy is killed
    private GameObject randomItem()
    {
        //20 percent chance that item spawned is healthPotion
        GameObject itemDrop = Random.value >= _chanceOfSpawning ? healthPotion : coin;
        return itemDrop;
    }

    //Called by enemy, spawns an item upon death
    public void SpawnItem(Vector3 enemyPos) => Instantiate(randomItem(), enemyPos, Quaternion.identity);

}
