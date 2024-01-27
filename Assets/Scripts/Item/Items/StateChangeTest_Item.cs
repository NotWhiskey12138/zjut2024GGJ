using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChangeTest_Item : Item
{
    StateChangeTest_Item(Item_SO itemData, VoidEventSO itemEvent) : base(itemData, itemEvent)
    {

    }
    public override void OnItemEvent()
    {
        base.OnItemEvent();
        ////获取player实例
        //GameObject player = transform.parent.gameObject;
        //PlayerController controller = player.GetComponent<PlayerController>();

        //启用飞行
        //controller.inputControl.Player.Use.started += fly;
        //controller.setCapacity(1);
    }
}
