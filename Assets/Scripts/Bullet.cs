using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
<<<<<<< Updated upstream
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setVelocity(Vector2 direction, float speed)
    {
        rb.velocity = direction * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy")) { //当子弹打到敌人后
           
        } 
=======
    private bool shotFrom;//true == 1,false ==2;
    private Rigidbody2D rb;
  
    public void SetBullet(Vector2 direction, float speed, bool fromPlayer) {
        rb.velocity = direction * speed;
        shotFrom = fromPlayer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (shotFrom) {
            if (collision.CompareTag("player2"))
            {
                PlayerTwoController.Instance.PlayerDead();
            }
                }
        else {
            if (collision.CompareTag("player1"))

            {
                PlayerController.Instance.PlayerDead();
            }
        }
>>>>>>> Stashed changes
    }
}
