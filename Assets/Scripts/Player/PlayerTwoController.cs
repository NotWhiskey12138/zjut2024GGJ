using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class PlayerTwoController : MonoBehaviour
{
    public Player2 inputControl;
    public Vector2 inputDirection;
    public Rigidbody2D rb;
    public PhysicsCheck physicsCheck;
    public DeathCheck deathCheck;
    public CapsuleCollider2D coll;
    //public FurirenAnmation furierenAnimation;

    [Header("�������")]
    public PhysicsMaterial2D normal;
    public PhysicsMaterial2D wall;

    [Header("������ֵ")]
    public float speed;
    public float jumpForce;
    public bool isDead;

    [Header("��ǰ������")]
    [SerializeField] private Item _item;
    public GameObject _item_obj;
    private Collider2D now_coll_item; //��¼��ǰ��ײ����
    private bool is_item_stillcoll;//��������Ƿ�����ҽ���

    [Header("���߹㲥")]
    public VoidEventSO Item_Event;

    [Header("��ɫλ���¼�")]
    public VoidEventSO PlayerAddForceEventSO;

    private void Awake()
    {
        inputControl = new Player2();
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

    #region basic status
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

    public void outsideDeath()//���������ж�
    {
        if (deathCheck.isDead)
            PlayerDead();
    }
    #endregion

    #region �������

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            now_coll_item = other;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Item") && now_coll_item == other)
            is_item_stillcoll = true;
        else
            is_item_stillcoll = false;
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
        if (is_item_stillcoll)
        {
            var item = now_coll_item.GetComponentInParent<Item>();

            _item = item;
            _item.gameObject.SetActive(false);
            _item_obj.GetComponentInChildren<SpriteRenderer>().color = _item_obj.GetComponentInChildren<SpriteRenderer>().color;
            _item_obj.SetActive(true);
            Item_Event = item.itemEventSO;
        }

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
        //PlayerAddForceEventSO
    }

    #endregion
}
