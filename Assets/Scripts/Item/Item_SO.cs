using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    toMove,drawin,boom
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item_SO : ScriptableObject
{
    public int itemId;
    public string itemName;
    public ItemType itemType;
    public Sprite itemIcon;
    
}
