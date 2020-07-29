using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour,IEnemy
{
    [SerializeField] private int _enemyHP;

    private PlayerCombat _player;
    private SpawnManager _spawner;
    private EnemyItemSpawn _itemSpawner;
    private int _enemyDamage, _enemyMaxHealth;

    public Enemy_SO enemy;

    public int EnemyDamage { get => enemy.enemyDamage; set => _enemyDamage = value; }
    public int EnemyHP { get => enemy.enemyHealth; set => _enemyHP = value; }
    public int EnemyMaxHP { get => enemy.enemyMaxHP; set => _enemyMaxHealth = value; }



    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        _spawner = FindObjectOfType<SpawnManager>();
        _itemSpawner = FindObjectOfType<EnemyItemSpawn>();
        
    }

    private void OnEnable()
    {
        _enemyHP = EnemyMaxHP;
        
    }

    private void OnDisable()
    {
        _spawner.RemoveSpawn();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            GiveDamage(EnemyDamage);
    }

    public void TakeDamage(int damage) 
    {
        if (_enemyHP >= 1)
        {
            _enemyHP -= damage;
        }
        else
        {
            _itemSpawner.SpawnItem(new Vector3(transform.position.x,transform.position.y,0));
            Death();// Need to add a death method
        }
    }

    public void GiveDamage(int damage) => _player.TakeDamage(damage);

    public void Death()
    {
        Destroy(this.gameObject);
    }
    


}
