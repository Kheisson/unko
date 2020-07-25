using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies;
    public List<Transform> spawnPoints;
    public List<string> enemyCount;


    public void SpawnEnemies(int waveCount)
    {
        for (int i = waveCount; i > 0; i--)
        {
            GameObject enemy = enemies[Random.Range(0, enemies.Count)];
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Vector3 randomPos = new Vector3(spawnPoints[randomIndex].transform.position.x, spawnPoints[randomIndex].transform.position.y, 0);
            Instantiate(enemy, randomPos, Quaternion.identity);
            enemyCount.Add("ADDED");
        }
    }

    public void RemoveSpawn() => enemyCount.RemoveAt(enemyCount.Count - 1);

    // spawn for number of wave count, remove enemy from list of enemies, wait for next wave

}
