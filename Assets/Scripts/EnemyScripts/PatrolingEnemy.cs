using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class PatrolingEnemy : Enemy
{
    private bool _isPatroling;
    private float _patrolTime = 5f;
    private int _destPoint = 0;
    private GameObject _playerPos;
    private AIDestinationSetter _setter;
    private EnemyItemSpawn _itemSpawner;
    private SpawnManager _spawner;

    private void OnEnable()
    {
        base.Start();
        _isPatroling = true;
        SpawnManager.enemyCounter++;
        StartCoroutine(EnemyPatrol(_patrolTime));
    }
    private void Awake()
    {
        _setter = GetComponent<AIDestinationSetter>();
        _itemSpawner = FindObjectOfType<EnemyItemSpawn>();
        _spawner = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _playerPos = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Update()
    {
        //Checks for player position and sets the destination on gameobject to said position
        if (_playerPos != null)
        {
            Vector2 playerPosition = new Vector2(_playerPos.transform.position.x, _playerPos.transform.position.y);

            if (Vector2.Distance(playerPosition, transform.position) < 3)
            {
                _isPatroling = false;
                _setter.target = _playerPos.transform;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            base.GiveDamage(_playerPos.GetComponent<PlayerCombat>());
    }

    //Patroling enemy function, circles through waypoins
    private IEnumerator EnemyPatrol(float patrolTime)
    {
        while (_isPatroling)
        {
            if (_spawner.spawnPoints.Count == 0)
            {
                Debug.LogError("No Waypoints for Patrol!");
                yield return null;
            }
            else
            {
                _destPoint %= _spawner.spawnPoints.Count;
                _setter.target = _spawner.spawnPoints[_destPoint];
                _destPoint++;
            }
            yield return new WaitForSeconds(patrolTime);
        }
    }

    private void OnDisable()
    {
        SpawnManager.enemyCounter--;
        _itemSpawner.SpawnItem(new Vector3(transform.position.x, transform.position.y, 0));
    }
}
