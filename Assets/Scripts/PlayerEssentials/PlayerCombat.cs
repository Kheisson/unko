﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    [Header("Player Stats")]
    public int playerDamage;
    public Weapon_SO weapon;

    [Header("UI elements")]
    public Slider healthBar;
    public Slider staminaBar;

    private int _playerHP, _weaponSpeed;
    private int _playerMaxHP = 100;
    private int _stamina = 150;
    private float _fireTimer;
    private bool _canShoot = true;
    private GameObject _spawnPos;
    private Coroutine _replenishStamina;


    // Start is called before the first frame update
    private void Start()
    {
        _weaponSpeed = weapon.fireRate;
        _playerHP = _playerMaxHP;
        _spawnPos = GameObject.Find("ItemHold");
        _fireTimer = (float)_weaponSpeed / 100;
        playerDamage = weapon.damage;
        healthBar.value = _playerHP;
        staminaBar.value = _stamina;

    }

    // Update is called once per frame
    private void Update()
    {
        if (_canShoot)
            Shoot();
    }


    private void Shoot()
    {
        if (Input.GetButton("Fire1") && staminaBar.value > 0)
        {
            GameObject bulletShoot = (GameObject)Instantiate(weapon.bulletPrefab, _spawnPos.transform.position, Quaternion.identity);
            Vector2 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = cursorInWorldPos - myPos;
            direction.Normalize();
            bulletShoot.GetComponent<Rigidbody2D>().velocity = direction * _weaponSpeed;
            staminaBar.value -= 10;
            if (_replenishStamina != null) { StopCoroutine(_replenishStamina); }

            _replenishStamina = StartCoroutine(ReplenishStamina());
            _canShoot = false;
            Invoke("CanShootAgain", 0.3f);
        }
    }

    private void CanShootAgain() => _canShoot = true;


    private void Death()
    {
        Destroy(gameObject);
        //Need to display game over and SFX
    }

    private IEnumerator ReplenishStamina()
    {

        yield return new WaitForSeconds(2);
        while (staminaBar.value < _stamina)
        {
            for (int i = (int)staminaBar.value; i < _stamina; i++)
            {
                staminaBar.value += 3;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (_playerHP >= 1)
        {
            _playerHP -= damage; 
            healthBar.value = _playerHP;
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
            healthBar.value = _playerHP;
        } else
        {
            _playerHP = _playerMaxHP;
            healthBar.value = _playerMaxHP;
        }
    }

}
