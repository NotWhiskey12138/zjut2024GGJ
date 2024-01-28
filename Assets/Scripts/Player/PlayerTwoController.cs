using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerTwoController : MonoBehaviour
{
    
        // Ë½ÓÐµÄ¾²Ì¬±äÁ¿£¬ÓÃÓÚ´æ´¢µ¥ÀýÊµÀý
        private static PlayerTwoController instance;

        // Ë½ÓÐµÄ¹¹Ôìº¯Êý£¬·ÀÖ¹Íâ²¿ÊµÀý»¯¶ÔÏó
        private PlayerTwoController() { }

        // ¹«¹²µÄ¾²Ì¬ÊôÐÔ»ò·½·¨£¬ÓÃÓÚ»ñÈ¡µ¥ÀýÊµÀý
        public static PlayerTwoController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerTwoController();
                }
                return instance;
            }
        }


    public Player2 inputControl;
    public Vector2 inputDirection;
    public Rigidbody2D rb;
    public PhysicsCheck physicsCheck;
    public DeathCheck deathCheck;
    public CapsuleCollider2D coll;
<<<<<<< Updated upstream
    //public FurirenAnmation furierenAnimation;
    
    [Header("ÎïÀí²ÄÖÊ")]
    public PhysicsMaterial2D normal;
    public PhysicsMaterial2D wall;
    
    [Header("ÊôÐÔÊýÖµ")]
    public float speed;
=======
    public bool isLongPressing;
    public float longPressDuration = 1.0f;
    public float currentPressTime = 0.0f;
    //public FurirenAnmation furierenAnimation;

    [Header("")]
    public PhysicsMaterial2D normal;
    public PhysicsMaterial2D wall;

    [Header("Öµ")]
    public float speed = 290;
    public float dashSpeed = 10;
>>>>>>> Stashed changes
    public float jumpForce;
    public float flyForce;
    public bool isDead;
<<<<<<< Updated upstream
    
    [Header("µ±Ç°µÀ¾ßÀ¸")] 
    [SerializeField]private Item _item; 
=======
    private bool isDash;

    [Header("Ç°")]
    [SerializeField] private Item _item;
>>>>>>> Stashed changes
    public GameObject _item_obj;
    private Collider2D now_coll_item; //Â¼Ç°×²
    private bool is_item_stillcoll;//Ç·Ò½

<<<<<<< Updated upstream
    [Header("µÀ¾ß¹ã²¥")] 
    public VoidEventSO Item_Event;

    [Header("ÆäËû")]
    [SerializeField] float jumpPressWindow;
=======
    [Header("ß¹ã²¥")]
    public VoidEventSO Item_Event;

    [Header("å…¶ä»–")]
    [SerializeField] float jumpPressWindow;
    [SerializeField] GameObject chicken;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed;
>>>>>>> Stashed changes
    private float fallMultiplier = 1.5f;
    private float lowJumpMultiplier = 1f;
    private bool isJump = false;
    private float jumpTime = 0;
<<<<<<< Updated upstream
=======
    private int faceDir;
    private bool activateOrCancle;
    private Transform chickenTransform;

>>>>>>> Stashed changes
    private void Awake()
    {
        inputControl = new Player2();
        inputControl.Player.Jump.started += Jump;
        inputControl.Player.Jump.canceled += BetterJump;

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
    {   if (!isDash)
            run();
        else
            dash();
        stateCheck();
        outsideDeath();
    }
    
    public void run()
    {
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);
         faceDir = (int)transform.localScale.x;
        if (inputDirection.x < 0)
            faceDir = -1;
        else if (inputDirection.x > 0)
            faceDir = 1;
        //×ª
        transform.localScale = new Vector3(faceDir, 1, 1);
    }
    public void shoot()
    {

        GameObject go = Instantiate(bullet, transform.position, Quaternion.identity);
        go.GetComponent<Bullet>().SetBullet(new Vector2(faceDir, 0), bulletSpeed, true);

    }
    public void dash()
    {
        rb.velocity = new Vector2(faceDir * dashSpeed, rb.velocity.y);
    }
    public void throwChicken()
    {
        GameObject go = Instantiate(chicken, transform.position, Quaternion.identity);
        go.AddComponent<Rigidbody2D>().velocity = new Vector2(3.0f, 2.0f);
        chickenTransform = go.GetComponent<Transform>();

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
    private void jumpTimeUpdate()
    {
        jumpTime += Time.deltaTime;
    }
    public void BetterJump(InputAction.CallbackContext context)
    {

        if (jumpTime >= jumpPressWindow)
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier;
        else if (jumpTime < jumpPressWindow)
            rb.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier;
        isJump = false;
        jumpTime = 0;
    }
    public void fly()
    {
        rb.AddForce(transform.up * jumpForce);
    }
<<<<<<< Updated upstream
=======
  
>>>>>>> Stashed changes
    public void stateCheck()
    {
        coll.sharedMaterial = physicsCheck.isGround ? normal : wall;
    }

    public void outsideDeath()//Ð¶
    {
        if(deathCheck.isDead)
            PlayerDead();
    }

    #region 

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            now_coll_item = other;
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player1") && isDash)
        {
            isDash = false;
           // collision.gameObject.GetComponent<>
        }
    }
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
    /// Ã»Ðµ
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
    /// 
    /// </summary>
    /// <param name="item"></param>
    public void Pickup_Item(InputAction.CallbackContext context)
    {
        if (is_item_stillcoll&&now_coll_item!=null)
        {
            var item = now_coll_item.GetComponentInParent<Item>();
            
            _item = item;
            Item_Event = item.itemEventSO;
            _item.gameObject.SetActive(false);
            _item_obj.GetComponentInChildren<SpriteRenderer>().sprite = item.GetComponentInChildren<SpriteRenderer>().sprite;
            _item_obj.SetActive(true);
        }
        
    }
    
    /// <summary>
    /// Ê¹Ãµ
    /// </summary>
    /// <param name="context"></param>
    private void Use_Item(InputAction.CallbackContext context)
    {
        _item.AddItemEvent();
        Item_Event.RaiseEvent();
        _item.removeItemEvent();
    }


    #endregion

    #region É«Î»

    public void AddPlayerForce(float force,Vector2 dir)
    {
<<<<<<< Updated upstream
=======
        Debug.Log("player2addForce");
        Vector2 dir = new Vector2(0, 5);
        int force = 50;
>>>>>>> Stashed changes
        rb.AddForce(dir * force);
    }

    public void activateOrCancleElbow()
    {
        if (activateOrCancle)
        {
            isDash = true;
            activateOrCancle = false;
        }
        else
        {
            isDash = false;
            activateOrCancle = true;
        }


    }
    #endregion
<<<<<<< Updated upstream
=======
    public int getPlayerID()
    {
        return playerID;
    }
    //public void setCapacity(int num)
    //{
    //    inputControl.Player.Use.RemoveAction();
    //    switch (num)
    //    {
    //        case 0:
    //            inputControl.Player.Use.performed += Fly;
    //            break;
    //        default:
    //            inputControl.Player.Use.started += Somecapacity;
    //            break;
    //    }
    //}

    //private void Somecapacity(InputAction.CallbackContext context)
    //{
    //    speed = 500;
    //}

    //private void Fly(InputAction.CallbackContext context)
    //{
    //    rb.AddForce(transform.up * betterJumpForce, ForceMode2D.Impulse);
    //}
    public void setIsLongPressing(bool flag)
    {
        isLongPressing = flag;
    }
    public bool getIslongPressing()
    {
        return isLongPressing;
    }
>>>>>>> Stashed changes
}
