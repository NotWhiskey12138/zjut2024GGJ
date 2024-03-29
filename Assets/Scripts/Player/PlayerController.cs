using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoSingleton<PlayerController>
{
    public static int playerID = 1;
    public ZJUT2024GGJ inputControl;
    public Vector2 inputDirection;
    public Rigidbody2D rb;
    public PhysicsCheck physicsCheck;
    public DeathCheck deathCheck;
    public CapsuleCollider2D coll;
    public bool isLongPressing;
    //public FurirenAnmation furierenAnimation;
    
    [Header("物理材质")]
    public PhysicsMaterial2D normal;
    public PhysicsMaterial2D wall;
    
    [Header("属性数值")]
    public float speed = 290;
    public float jumpForce;
    public float betterJumpForce;
    public bool isDead;
    
    [Header("当前道具栏")] 
    [SerializeField]private Item _item; 
    public GameObject _item_obj;
    private Collider2D now_coll_item; //记录当前碰撞物体
    private bool is_item_stillcoll;//检测物体是否在玩家脚下

    [Header("道具广播")] 
    public VoidEventSO Item_Event;

    
    private void Awake()
    {
        inputControl = new ZJUT2024GGJ();
        inputControl.Player.Jump.started += Jump;
        
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        deathCheck = GetComponent<DeathCheck>();

        now_coll_item = null;
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
        //rb= GetComponent<Rigidbody2D>();

        CheckIfHaveItem();
        Debug.Log(now_coll_item);
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
        //人物翻转
        transform.localScale = new Vector3(faceDir, 1, 1);
        Debug.Log("player1moved");
    }

    public void PlayerDead()
    {
        isDead = true;
        inputControl.Player.Disable();
        Debug.Log("player1 is dead");
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGround)
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    
    public void stateCheck()
    {
        coll.sharedMaterial = physicsCheck.isGround ? normal : wall;
    }

    public void outsideDeath()//出界死亡判定
    {
        if(deathCheck.isDead)
            PlayerDead();
    }

    #region 道具相关

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            now_coll_item = other;
        }
    }*/

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            is_item_stillcoll = true;
            now_coll_item = other;
        }
        else
        {
            is_item_stillcoll = false;
            now_coll_item = null;
        }
    }

    /// <summary>
    /// 检测手上有没有道具
    /// </summary>
    private void CheckIfHaveItem()
    {
        inputControl.Player.Use.started += Pickup_Item;

        if (_item != null)
        {
            inputControl.Player.Use.started += Use_Item;
        }
        else
        {
            inputControl.Player.Use.started -= Use_Item;
        }


    }

    /// <summary>
    /// 捡起道具
    /// </summary>
    /// <param name="item"></param>
    public void Pickup_Item(InputAction.CallbackContext context)
    {
        if (is_item_stillcoll&&now_coll_item!=null)
        {
            var item = now_coll_item.GetComponentInParent<Item>();
            
            Item.Instance.If1Haveit();
            _item = item;
            Item_Event = item.itemEventSO;
            _item.gameObject.SetActive(false);
            _item_obj.GetComponentInChildren<SpriteRenderer>().sprite = item.GetComponentInChildren<SpriteRenderer>().sprite;
            _item_obj.SetActive(true);
        }
        
    }
    
    /// <summary>
    /// 使用道具
    /// </summary>
    /// <param name="context"></param>
    private void Use_Item(InputAction.CallbackContext context)
    {
        _item.AddItemEvent();
        Item_Event.RaiseEvent();
        _item.removeItemEvent();
    }


    #endregion

    #region 角色被位移

    public void AddPlayerForce()
    {
        Debug.Log("ADDFORCE被触发了" );
        Vector2 dir= new Vector2(0, 5);
        int force = 50;
        rb.AddForce(dir*force);
    }



    #endregion



    public int getPlayerID()
    {
        return playerID;
    }
    public void setCapacity(int num)
    {
        inputControl.Player.Use.RemoveAction();
        switch (num)
        {
            case 0:
                inputControl.Player.Use.performed += Fly;
                break;
            default:
                inputControl.Player.Use.started += Somecapacity;
                break;
        }
    }

    private void Somecapacity(InputAction.CallbackContext context)
    {
        speed = 500;
    }

    private void Fly(InputAction.CallbackContext context)
    {
        rb.AddForce(transform.up * betterJumpForce, ForceMode2D.Impulse);
    }
}
