using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet_Item : Item
{
    public bullet_Item(Item_SO itemData, VoidEventSO itemEvent) : base(itemData, itemEvent)
    {

    }
    public override void OnItemEvent()
    {
        base.OnItemEvent();
        Debug.Log("executed");
        if (Item.Instance.getIf2Haveit())
        {
            
            PlayerTwoController.Instance.shoot();
            Debug.Log("p2 shooting");
            Musiceffect.Instance.PlaySoundBullet();
        }
        else
        {
            PlayerController.Instance.shoot();
            Debug.Log("p1 shooting");
            Musiceffect.instance.PlaySoundBullet();
        }
        Debug.Log("bullet_Item±ª¥•∑¢¡À");
    }
}
