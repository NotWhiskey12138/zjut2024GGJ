using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private PhysicsCheck physicsCheck;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
        anim = GetComponentInChildren<Animator>();  
        physicsCheck = GetComponent<PhysicsCheck>();    
    }

    private void Update()
    {
        setAnimation();
    }
    public void setAnimation()
    {
        anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGround", physicsCheck.isGround);
        anim.SetFloat("velocityY", rb.velocity.y);
    }
}
