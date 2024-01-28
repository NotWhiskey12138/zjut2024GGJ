using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerTwoController : MonoSingleton<PlayerTwoController>
{
    public static int playerID = 2;
    public Player2 inputControl;
    public Vector2 inputDirection;
    public Rigidbody2D rb;
    public PhysicsCheck physicsCheck;
    public DeathCheck deathCheck;
    public CapsuleCollider2D coll;
    public bool isLongPressing;
    public float longPressDuration = 1.0f;
    public float currentPressTime = 0.0f;
    public Transform playerTransform;
    public Vector2 playerPosition;
    public StageCheck stageCheck;
    public int deathCounter= 0;
    public AudioSource audioSource;
    public AudioClip audioClip;
    //public FurirenAnmation furierenAnimation;

    [Header("��������")]
    public PhysicsMaterial2D normal;
    public PhysicsMaterial2D wall;

    [Header("������ֵ")]
    public float speed = 290;
    public float jumpForce;
    public float betterJumpForce;
    public bool isDead;

    [Header("��ǰ������")]
    [SerializeField] private Item _item;
    public GameObject _item_obj;
    private Collider2D now_coll_item; //��¼��ǰ��ײ����
    private bool is_item_stillcoll;//��������Ƿ�����ҽ���

    [Header("���߹㲥")]
    public VoidEventSO Item_Event;

    [Header("����ʿ����")] public Animation HLS_Aim;

    [Header("Item")]
    [SerializeField] private GameObject chicken;
    [SerializeField] private float dashSpeed;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float jumpPressWindow;
    [SerializeField] private float fallMultiplier = 1.5f;
    [SerializeField] private float lowJumpMultiplier = 1f;
    private float jumpTime;
    private Transform chickenTransform;
    private int faceDir;
    private bool isDash;
    private bool isJump;

    private void Awake()
    {
        inputControl = new Player2();
        inputControl.Player.Jump.started += Jump;

    }
    private void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerPosition = playerTransform.position;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        deathCheck = GetComponent<DeathCheck>();
        stageCheck = GetComponent<StageCheck>();

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
        if (!isDash)
            run();
        else
            dash();
        stateCheck();
        outsideDeath();
    }
    #region ����״̬
    public void run()
    {
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);
        faceDir = (int)transform.localScale.x;
        if (inputDirection.x < 0)
            faceDir = -1;
        else if (inputDirection.x > 0)
            faceDir = 1;
        //���﷭ת
        transform.localScale = new Vector3(faceDir, 1, 1);
        Debug.Log("player1moved");
    }

    public void PlayerDead()
    {
        isDead = true;
        //inputControl.Player.Disable();
        playerTransform.position = playerPosition;
        deathCounter++;
        Debug.Log("player1 is dead" + deathCounter + " times");
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGround)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            Musiceffect.Instance.PlaySoundEffect();
        }
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
    public void activateOrCancleElbow()
    {
        if (!isDash)
        {
            isDash = true;

        }
        else
        {
            isDash = false;

        }
    }
    public void throwChicken()
    {
        GameObject go = Instantiate(chicken, transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        chickenTransform = go.transform;

    }
    public void transition()
    {
        transform.position = chickenTransform.position;
    }
    public void dash()
    {
        rb.velocity = new Vector2(dashSpeed * faceDir, rb.velocity.y);
    }
    public void shoot()
    {
        GameObject go = Instantiate(bullet, transform.position, Quaternion.identity);
        go.GetComponent<Bullet>().SetBullet(new Vector2(faceDir, 0), bulletSpeed, false);
    }
    public void stateCheck()
    {
        coll.sharedMaterial = physicsCheck.isGround ? normal : wall;
    }

    public void outsideDeath()//���������ж�
    {
        if (deathCheck.isDead)
            PlayerDead();
    }
    #endregion

    #region �������

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            now_coll_item = other;
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDash)
            if (collision.CompareTag("player2"))
            {
                isDash = false;
                PlayerTwoController.Instance.AddPlayerForce();
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
    /// ���������û�е���
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
    /// �������
    /// </summary>
    /// <param name="item"></param>
    public void Pickup_Item(InputAction.CallbackContext context)
    {
        if (is_item_stillcoll && now_coll_item != null)
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

    public void ClearItem()
    {
        _item = null;
        Item_Event = null;
        _item_obj.SetActive(false);
    }

    /// <summary>
    /// ʹ�õ���
    /// </summary>
    /// <param name="context"></param>
    private void Use_Item(InputAction.CallbackContext context)
    {
        _item.AddItemEvent();
        Item_Event.RaiseEvent();
        _item.removeItemEvent();
    }


    #endregion

    #region ��ɫ��λ��

    public void AddPlayerForce()
    {
        Debug.Log("ADDFORCE��������");
        Vector2 dir = new Vector2(0, 5);
        int force = 50;
        rb.AddForce(dir * force);
    }



    #endregion

    //����ʿ�������ţ�
    public void HLS_Shoot_True()
    {

        HLS_Aim.Play();
    }


    public void setIsLongPressing(bool flag)
    {
        isLongPressing = flag;
    }


    public bool getIsLongPressing()
    {
        return isLongPressing;
    }


    //�ж��Ƿ�ͨ���յ�
    public bool getIsStage()
    {
        return stageCheck.isStage;
    }

    #region DLW(�����޸�)
    public void massChange()
    {
        rb.mass = 5;
    }
    #endregion
}
