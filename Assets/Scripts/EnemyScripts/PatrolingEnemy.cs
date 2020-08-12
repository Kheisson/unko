using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class PatrolingEnemy : MonoBehaviour
{
    [SerializeField] private bool isPatroling = true;
    private float _patrolTime = 5f;
    private float _attackInterval = 0;
    private int _destPoint = 0;
    private GameObject _playerPos;
    private AIDestinationSetter _setter;
    private List<Transform> _waypoints;
    private Enemy _enemyBaseClass;

    private void Start()
    {
        _setter = GetComponent<AIDestinationSetter>();
        _playerPos = GameObject.FindGameObjectWithTag("Player");
        _waypoints = GameObject.FindObjectOfType<SpawnManager>().spawnPoints;
        _enemyBaseClass = GetComponent<Enemy>();
        StartCoroutine(EnemyPatrol(_patrolTime));
    }

    
    private void Update()
    {
        //Checks for player position and sets the destination on gameobject to said position
        if (_playerPos != null)
        {
            Vector2 playerPosition = new Vector2(_playerPos.transform.position.x, _playerPos.transform.position.y);

            if (Vector2.Distance(playerPosition, transform.position) < 3)
            {
                isPatroling = false;
                _setter.target = _playerPos.transform;

                if (Time.time > _attackInterval)
                {
                    _enemyBaseClass.InitiateAttack(transform.position, _playerPos.transform.position, 4);
                    _attackInterval = 2 + Time.time;
                }
            }
        }
    }

    //Patroling enemy function, circles through waypoins
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
                _destPoint %= _waypoints.Count;
                _setter.target = _waypoints[_destPoint];
                _destPoint++;
            }
            yield return new WaitForSeconds(patrolTime);
        }
    }
}
