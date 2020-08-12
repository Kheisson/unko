using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<Transform> spawnPoints;
    public List<string> enemyCount;
    public static int enemyCounter;


    // Spawning enemies per round, called in game manager script
    public void SpawnEnemies(int waveCount)
    {
        for (int i = waveCount; i > 0; i--)
        {
            GameObject enemy = enemies[Random.Range(0, enemies.Count)];
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Vector3 randomPos = new Vector3(spawnPoints[randomIndex].transform.position.x, spawnPoints[randomIndex].transform.position.y, 0);
            Instantiate(enemy, randomPos, Quaternion.identity);
            enemyCount.Add("ADDED"); //this lists job is to keep track of enemies spawned 
        }
    }

    //Each time an enemy is destroyed an entry in the list is removed, called in enemy script
    public void RemoveSpawn() => enemyCount.RemoveAt(enemyCount.Count - 1);

}
