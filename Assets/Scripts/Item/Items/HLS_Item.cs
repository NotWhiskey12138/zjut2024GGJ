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
        //��ȡplayerʵ��
        GameObject player = transform.parent.gameObject;
        PlayerController controller = player.GetComponent<PlayerController>();
        //controller.inputControl.Player.Use.canceled += removeItemEvent;
        //���÷���
        //controller.inputControl.Player.Use.started += fly;
    }
}
