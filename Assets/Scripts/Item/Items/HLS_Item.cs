using System.Collections;
using System.Collections.Generic;
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
        // GameObject player = transform.parent.gameObject;
        // PlayerController controller = player.GetComponent<PlayerController>();
        //
        // //���÷���
        // //controller.inputControl.Player.Use.started += fly;
        // controller.setCapacity(0);
        if (Item.Instance.getIf2Haveit())
        {
            PlayerTwoController.Instance.inputControl.Player.Use.performed += _ => { isPaused = true; };
            PlayerTwoController.Instance.AddPlayerForce();
        }
        else
        {
            PlayerController.Instance.AddPlayerForce();
        }
        Debug.Log("HLS_Item被触发了");
    }
}
