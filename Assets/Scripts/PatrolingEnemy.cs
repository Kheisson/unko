using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class PatrolingEnemy : MonoBehaviour
{
    [SerializeField] private bool isPatroling = true;

    private float _patrolTime = 5f;
    private int _destPoint = 0;
    private Transform _playerPos;
    private GameObject _player;
    private AIDestinationSetter _setter;
    private SpawnManager _spawner;
    private List<Transform> _waypoints;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _spawner = FindObjectOfType<SpawnManager>();
        _setter = GetComponent<AIDestinationSetter>();
        _playerPos = _player.transform;
        _waypoints = _spawner.spawnPoints;
        StartCoroutine(EnemyPatrol(_patrolTime));
    }


    private void Update()
    {
        Vector2 playerPosition = new Vector2(_playerPos.transform.position.x, _playerPos.transform.position.y);

        if (Vector2.Distance(playerPosition, transform.position) < 3)
        {
            isPatroling = false;
            _setter.target = _playerPos.transform;

        }
    }


    private IEnumerator EnemyPatrol(float patrolTime)
    {
        while (isPatroling)
        {
            if (_waypoints.Count == 0)
            {
                Debug.LogError("No Waypoints for Patrol!");
                yield return null;
            }
            else
            {
                _destPoint = _destPoint % _waypoints.Count;
                _setter.target = _waypoints[_destPoint];
                _destPoint++;
            }
            yield return new WaitForSeconds(patrolTime);
        }
    }
}
