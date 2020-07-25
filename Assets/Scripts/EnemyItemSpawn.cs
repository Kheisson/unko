using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItemSpawn : MonoBehaviour
{
    public List<GameObject> spawnableObjects = new List<GameObject>();

    private GameObject randomItem()
    {
        int randomIndex = Random.Range(0, spawnableObjects.Count);
        GameObject spawnedItem = spawnableObjects[randomIndex];

        return spawnedItem;
    }

    public void SpawnItem(Vector3 enemyPos)
    {
        Debug.Log($"SpawnItem called {enemyPos}");
        Instantiate(randomItem(), enemyPos, Quaternion.identity);
    }


}
