using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Spawnable/Weapon")]
public class Weapon_SO : ScriptableObject
{
   
    public GameObject bulletPrefab; // Stores out Bullet Prefab
    
    public string weaponName;        // weapon name e.g  plasma cannon
    public string weaponDescription;// weapon description e.g "Fires plasma ball"
    public int fireRate;           // bullets shot per second 1f (1 per second)
    public int damage;            // damage per bullet (100)
    public int priceOfWeapon;    // Price in shop
    // public Sprite to be added

}
