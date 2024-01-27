using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("物品数据")] public Item_SO itemData;

    [Header("物品事件")] public VoidEventSO itemEventSO;

    public Item(Item_SO itemData, VoidEventSO itemEvent)
    {
        this.itemData = itemData;
        this.itemEventSO = itemEvent;
    }

    public virtual void AddItemEvent()
    {
        itemEventSO.OnEventRaised += OnItemEvent;
    }

    public virtual void removeItemEvent()
    {
        itemEventSO.OnEventRaised -= OnItemEvent;
    }

    public virtual void OnItemEvent()
    {
        Debug.Log(itemData.itemName + "被触发了");
        //清除当前玩家的能力
        //加入该能力
    }
}
    