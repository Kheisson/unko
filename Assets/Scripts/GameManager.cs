using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _currentLevel = 1; // Need to give spawnManager the wavecount
    private SpawnManager _spawner;

    public WaveCounter WaveCounterUI;
    public bool gameOver;

    void Start()
    {
        _spawner = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        StartCoroutine("SuspendExecution");
    }

    //When all of the enemies are killed suspend and add one to level
    private IEnumerator SuspendExecution()
    {
        while (!gameOver)
        {
            if (SpawnManager.enemyCounter == 0)
            {
                WaveCounterUI.WaveAnimator(_currentLevel);
                _spawner.SpawnEnemies(_currentLevel);
                _currentLevel++;
            }
            yield return new WaitForSeconds(10f);
        }
    }







}
