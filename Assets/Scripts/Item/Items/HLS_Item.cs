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
        if (Item.Instance.getIf2Haveit())
        {
            //PlayerTwoController.Instance.inputControl.Player.Use.performed += _ => PlayerTwoController.Instance.setIsLongPressing(true);
            //if (PlayerTwoController.Instance.getIslongPressing())
            //{
            //    PlayerTwoController.Instance.currentPressTime += Time.deltaTime;
            //    Debug.Log("now pressing time is "+PlayerTwoController.Instance.currentPressTime);
            //}
            //PlayerTwoController.Instance.inputControl.Player.Use.canceled += _ => PlayerTwoController.Instance.setIsLongPressing(false);
            //while (PlayerTwoController.Instance.getIslongPressing())
            //{
            //    
            //}
            PlayerTwoController.Instance.AddPlayerForce();
        }
        else
        {
            //PlayerController.Instance.inputControl.Player.Use.performed += _ => PlayerController.Instance.setIsLongPressing(true);
            //PlayerController.Instance.inputControl.Player.Use.canceled += _ => PlayerController.Instance.setIsLongPressing(false);
            //if(PlayerController.Instance.isLongPressing)
                PlayerController.Instance.AddPlayerForce();
        }
        Debug.Log("HLS_Item被触发了");
    }
}
