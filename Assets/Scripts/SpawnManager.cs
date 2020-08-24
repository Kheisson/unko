using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public List<WaveManager_SO> waveManager;
    public List<Transform> spawnPoints;
    public static int enemyCounter;

    //Spawning enemies per round, called in game manager script
    public void SpawnWave(int waveCount)
    {
        foreach (var enemy in waveManager[waveCount].enemiesToSpawn)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Vector3 randomPos = new Vector3(spawnPoints[randomIndex].transform.position.x, spawnPoints[randomIndex].transform.position.y, 0);
            Instantiate(enemy, randomPos, Quaternion.identity);
        }
    }
}
