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
        ////��ȡplayerʵ��
        //GameObject player = transform.parent.gameObject;
        //PlayerController controller = player.GetComponent<PlayerController>();

        //���÷���
        //controller.inputControl.Player.Use.started += fly;
        //controller.setCapacity(1);
    }
}
