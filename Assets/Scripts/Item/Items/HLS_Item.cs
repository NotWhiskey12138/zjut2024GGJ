using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HLS_Item : Item
{
    public HLS_Item(Item_SO itemData, VoidEventSO itemEvent) : base(itemData, itemEvent)
    {

    }
    public override void OnItemEvent()
    {
        base.OnItemEvent();
        //获取player实例
        //启用飞行
        
    }
}
