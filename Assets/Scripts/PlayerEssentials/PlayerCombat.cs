using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public int playerDamage;
    public Weapon_SO weapon;
    public Slider slider;

    private int _playerHP, _weaponSpeed;
    private int _playerMaxHP = 100;
    private GameObject _spawnPos;
    
    // Start is called before the first frame update
    void Start()
    {
        _weaponSpeed = weapon.fireRate;
        _playerHP = _playerMaxHP;
        _spawnPos = GameObject.Find("ItemHold");
        playerDamage = weapon.damage;
        slider.value = _playerHP;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }


    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bulletShoot = (GameObject)Instantiate(weapon.bulletPrefab, _spawnPos.transform.position, Quaternion.identity);
            Vector2 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = cursorInWorldPos - myPos;
            direction.Normalize();
            bulletShoot.GetComponent<Rigidbody2D>().velocity = direction * _weaponSpeed;

        }
    }

    private void Death()
    {
        Destroy(gameObject);
        //Need to display game over and SFX
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            var item = collision.GetComponent<ItemPickUp>().pickedUpItem;
            switch (item.itemType)
            {
                case ItemPickUp.ItemType.Potion:
                    AddHealth();
                    Destroy(collision.gameObject);
                    break;
                default:
                    break;
            }

        }
    }

    public void TakeDamage(int damage)
    {
        if (_playerHP >= 1)
        {
            _playerHP -= damage; //Need to add healthbar reduction
            slider.value = _playerHP;
        }
        else
        {
            Death();
        }
    }

    public void AddHealth()
    {
        if(_playerHP < _playerMaxHP)
        {
            _playerHP += 15;
            slider.value = _playerHP;
        } else
        {
            _playerHP = _playerMaxHP;
            slider.value = _playerMaxHP;
        }
    }


}
