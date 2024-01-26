using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public ZJUT2024GGJ inputControl;
    public Vector2 inputDirection;
    public Rigidbody2D rb;
    //public PhysicsCheck physicsCheck;
    public CapsuleCollider2D coll;
    //public FurirenAnmation furierenAnimation;
    //[Header("物理材质")]
    //public PhysicsMaterial2D normal;
    //public PhysicsMaterial2D wall;
    [Header("属性数值")]
    public float speed;
    public float jumpForce;
    public bool isDead;
    private void Awake()
    {
        inputControl = new ZJUT2024GGJ();
        
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inputControl.Player.Jump.started += Jump;
        coll = GetComponent<CapsuleCollider2D>();
    }

    

    private void OnEnable()
    {
        inputControl.Enable();
    }
    private void OnDisable()
    {
        inputControl.Disable();
    }
    private void Update()
    {
        inputDirection = inputControl.Player.Move.ReadValue<Vector2>();
        rb= GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        run();
    }
    
    public void run()
    {
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);
        int faceDir = (int)transform.localScale.x;
        if (inputDirection.x < 0)
            faceDir = -1;
        else if (inputDirection.x > 0)
            faceDir = 1;
        //人物翻转
        transform.localScale = new Vector3(faceDir, 1, 1);
    }

    public void PlayerDead()
    {
        isDead = true;
        inputControl.Player.Disable();
    }

    public void Jump(InputAction.CallbackContext context)
    {

    }
}
