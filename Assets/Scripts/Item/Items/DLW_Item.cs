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
        if (Item.Instance.getIf2Haveit())//��Ҷ�
        {
            PlayerTwoController.Instance.massChange();
        }
        else//���һ�ж�
        {
            PlayerController.Instance.massChange();
        }
        Debug.Log("DLW����������");
    }
}
