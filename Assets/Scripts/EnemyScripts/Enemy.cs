using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour,IEnemy
{
    [SerializeField] private int _enemyHP;

    protected PlayerCombat _player;
    protected EnemyItemSpawn _itemSpawner;
    protected Rigidbody2D _projectileRB;
    protected int _enemyDamage, _enemyMaxHealth, _projectileDamage;

    public GameObject projectileGO;
    public Enemy_SO enemy;

    public int EnemyDamage { get => enemy.enemyDamage; set => _enemyDamage = value; }
    public int EnemyHP { get => enemy.enemyHealth; set => _enemyHP = value; }
    public int EnemyMaxHP { get => enemy.enemyMaxHP; set => _enemyMaxHealth = value; }



    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        _itemSpawner = FindObjectOfType<EnemyItemSpawn>();
    }

    protected void OnEnable()
    {
        _enemyHP = EnemyMaxHP;
        SpawnManager.enemyCounter++;
    }

    protected void OnDisable()
    {
        SpawnManager.enemyCounter--;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            GiveDamage(EnemyDamage);
    }

    public void TakeDamage(int damage) 
    {
        if (_enemyHP > 0)
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

    public void InitiateAttack(Vector3 enemyLoc, Vector3 playerLoc, int attackSpeed)
    {
        GameObject projectile = Instantiate(projectileGO, enemyLoc, Quaternion.identity);
        _projectileRB = projectile.GetComponent<Rigidbody2D>();
        Vector2 direction = playerLoc - projectile.transform.position;
        direction.Normalize();
        projectile.transform.up = (playerLoc + projectile.transform.position);
        _projectileRB.velocity = direction * attackSpeed;
        _projectileDamage = projectile.GetComponent<EnemyProjectile>().damageToInflict;
        _projectileDamage = EnemyDamage;
    }

}
