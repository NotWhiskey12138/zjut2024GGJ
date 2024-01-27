using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class HLS_Item : Item
{
    public HLS_Item(Item_SO itemData, VoidEventSO itemEvent) : base(itemData, itemEvent)
    {

    }
    public override void OnItemEvent()
    {
        base.OnItemEvent();
        //获取player实例
        GameObject player = transform.parent.gameObject;
        PlayerController controller = player.GetComponent<PlayerController>();
        //controller.inputControl.Player.Use.canceled += removeItemEvent;
        //启用飞行
        //controller.inputControl.Player.Use.started += fly;
    }
}
