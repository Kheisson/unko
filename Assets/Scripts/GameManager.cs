using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _currentLevel = 1; // Need to give spawnManager the wavecount

    public WaveCounter WaveCounterUI;
    public bool gameOver;

    private SpawnManager _spawner;

    // Start is called before the first frame update
    void Start()
    {
        _spawner = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        StartCoroutine("SuspendExecution");
    }

    private IEnumerator SuspendExecution()
    {
        while (!gameOver)
        {
            if (_spawner.enemyCount.Count == 0)
            {
                WaveCounterUI.WaveAnimator(_currentLevel);
                _spawner.SpawnEnemies(_currentLevel);
                _currentLevel++;
            }
            yield return new WaitForSeconds(10f);
        }
    }







}
