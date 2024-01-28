using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shitAnimation : MonoBehaviour
{
    private Animator anim;
    private bool isGround;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        if (Item.Instance.getIf2Haveit())
        {
            isGround = PlayerTwoController.Instance.physicsCheck.isGround;
        }
        else
        {
            isGround = PlayerController.Instance.physicsCheck.isGround;
        }
    }

    private void Update()
    {
        setAnimation();
    }
    public void setAnimation()
    {
        
        anim.SetBool("isGround", isGround);
    }

    public void HLS_anim_Finish()
    {
        this.gameObject.SetActive(false);
    }
}
