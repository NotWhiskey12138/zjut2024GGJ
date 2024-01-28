using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
public class CXK_Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
=======
public class CXK_Item : Item
{
    public CXK_Item(Item_SO itemData, VoidEventSO itemEvent) : base(itemData, itemEvent)
    {

    }
    public override void OnItemEvent()
    {
        base.OnItemEvent();
        if (Item.Instance.getIf2Haveit())
        {

            PlayerTwoController.Instance.throwChicken();
        }
        else
        {
            //PlayerController.Instance.inputControl.Player.Use.performed += _ => PlayerController.Instance.setIsLongPressing(true);
            //PlayerController.Instance.inputControl.Player.Use.canceled += _ => PlayerController.Instance.setIsLongPressing(false);
            //if(PlayerController.Instance.isLongPressing)
            PlayerController.Instance.throwChicken();
        }
        Debug.Log("CXK_Item被触发了");
>>>>>>> Stashed changes
    }
}
