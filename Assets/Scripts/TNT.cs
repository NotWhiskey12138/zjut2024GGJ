using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{
    [SerializeField] private float velocityThread;
    
    Rigidbody2D rb;
    Animator anim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void explode() {
        anim.SetTrigger("explode");
    }
    void explodeEnd()
    {
        Destroy(gameObject);
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (rb.velocity.y > velocityThread)
        {
            explode();
            return;
        }
    }
    
}
