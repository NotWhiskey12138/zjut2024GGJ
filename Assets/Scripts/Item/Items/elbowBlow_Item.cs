
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElbowBlow_Item : Item
{
    public ElbowBlow_Item(Item_SO itemData, VoidEventSO itemEvent) : base(itemData, itemEvent)
    {

    }
    public override void OnItemEvent()
    {
        base.OnItemEvent();

        if (Item.Instance.getIf2Haveit())
        {

            PlayerTwoController.Instance.activateOrCancleElbow();
            Musiceffect.instance.PlaySoundElbow();
        }
        else
        {
            //PlayerController.Instance.inputControl.Player.Use.performed += _ => PlayerController.Instance.setIsLongPressing(true);
            //PlayerController.Instance.inputControl.Player.Use.canceled += _ => PlayerController.Instance.setIsLongPressing(false);
            //if(PlayerController.Instance.isLongPressing)
            PlayerController.Instance.activateOrCancleElbow();
            Musiceffect.instance.PlaySoundElbow();
        }
        Debug.Log("elbowBlow_Item被触发了");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
