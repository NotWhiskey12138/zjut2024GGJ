using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if (Item.Instance.getIf2Haveit())//玩家二
        {
            
            PlayerTwoController.Instance.AddPlayerForce();
        }
        else//玩家一行动
        {
            //PlayerController.Instance.inputControl.Player.Use.performed += _ => PlayerController.Instance.setIsLongPressing(true);
            //PlayerController.Instance.inputControl.Player.Use.canceled += _ => PlayerController.Instance.setIsLongPressing(false);
            //if(PlayerController.Instance.isLongPressing)
                PlayerController.Instance.AddPlayerForce();
        }
        Debug.Log("HLS_Item被触发了");
    }
}
