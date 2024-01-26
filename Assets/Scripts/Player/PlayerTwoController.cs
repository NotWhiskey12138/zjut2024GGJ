using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerTwoController : MonoBehaviour
{
    public Player2 inputControl2;
    public Vector2 inputDirection;
    public Rigidbody2D rb;
    public PhysicsCheck physicsCheck;
    public DeathCheck deathCheck;
    public CapsuleCollider2D coll;
    //public FurirenAnmation furierenAnimation;
    [Header("��������")]
    public PhysicsMaterial2D normal;
    public PhysicsMaterial2D wall;
    [Header("������ֵ")]
    public float speed;
    public float jumpForce;
    public bool isDead;
    private void Awake()
    {
        inputControl2 = new Player2();

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inputControl2.Player.Jump.started += Jump;
        coll = GetComponent<CapsuleCollider2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        deathCheck = GetComponent<DeathCheck>();
    }



    private void OnEnable()
    {
        inputControl2.Enable();
    }
    private void OnDisable()
    {
        inputControl2.Disable();
    }
    private void Update()
    {
        inputDirection = inputControl2.Player.Move.ReadValue<Vector2>();
        rb = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        run();
        stateCheck();
        outsideDeath();
    }

    public void run()
    {
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);
        int faceDir = (int)transform.localScale.x;
        if (inputDirection.x < 0)
            faceDir = -1;
        else if (inputDirection.x > 0)
            faceDir = 1;
        //���﷭ת
        transform.localScale = new Vector3(faceDir, 1, 1);
    }

    public void PlayerDead()
    {
        isDead = true;
        inputControl2.Player.Disable();
        Debug.Log("player2 is dead");
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGround)
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    public void stateCheck()//physics materia selector
    {
        coll.sharedMaterial = physicsCheck.isGround ? normal : wall;
    }

    public void outsideDeath()//���������ж�
    {
        if (deathCheck.isDead)
            PlayerDead();
    }
}