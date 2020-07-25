using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Spawnable/Item")]
public class Item_SO : ScriptableObject
{
    public string itemName;
    public ItemPickUp.ItemType itemType;
}
