using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COCO_Item : Item
{
    public float coco_force;
    public Vector2 dir;

    // Start is called before the first frame update
    public COCO_Item(Item_SO itemData, VoidEventSO itemEvent) : base(itemData, itemEvent)
    {
    }

    public override void AddItemEvent()
    {
        base.AddItemEvent();
    }

    public override void removeItemEvent()
    {
        base.removeItemEvent();
    }
    
    public override void OnItemEvent()
    {
        StartCoroutine(AddForceToPlayer());
    }

    IEnumerator AddForceToPlayer()
    {
        yield return new WaitForSeconds(1);
        PlayerController.Instance.AddPlayerForce(coco_force,dir);
    }
}
