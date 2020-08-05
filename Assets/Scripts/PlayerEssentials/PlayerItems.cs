using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    private PlayerCombat _playerCombatScript;


    void Start()
    {
        _playerCombatScript = GetComponent<PlayerCombat>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            var item = collision.GetComponent<ItemPickUp>().pickedUpItem.itemType;
            switch (item)
            {
                case ItemPickUp.ItemType.Potion:
                    _playerCombatScript.AddHealth();
                    break;
                case ItemPickUp.ItemType.Coin:
                    Debug.Log("Coin picked up");
                    break;
                default:
                    break;
            }
            Destroy(collision.gameObject);
        }
    }
}
