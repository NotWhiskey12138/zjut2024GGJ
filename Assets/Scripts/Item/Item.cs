using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoSingleton<Item>
{
    [Header("物品数据")] public Item_SO itemData;

    [Header("物品事件")] public VoidEventSO itemEventSO;

    private bool is1or2;//如果是0则为PLAYER1，如果是1则为Player2

    public Item(Item_SO itemData, VoidEventSO itemEvent)
    {
        this.itemData = itemData;
        this.itemEventSO = itemEvent;
    }

    private void Update()
    {
        Debug.Log("这个物品属于" + is1or2);
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
    }

    public void If1Haveit()
    {
        is1or2 = false;
    }

    public void If2Haveit()
    {
        is1or2 = true;
    }
    public bool getIf2Haveit()
    {
        return is1or2;
    }
}
    