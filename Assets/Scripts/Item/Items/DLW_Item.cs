using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLW_Item : Item
{
    public DLW_Item(Item_SO itemData, VoidEventSO itemEvent) : base(itemData, itemEvent)
    {

    }

    public override void OnItemEvent()
    {
        base.OnItemEvent();
        if (Item.Instance.getIf2Haveit())//玩家二
        {
            PlayerTwoController.Instance.massChange();
        }
        else//玩家一行动
        {
            PlayerController.Instance.massChange();
        }
        Debug.Log("DLW，被触发了");
    }
}
