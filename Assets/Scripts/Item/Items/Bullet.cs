using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

   
    public void setVelocity(Vector2 direction, float speed)
    {
        rb.velocity = direction * speed;
    }
 
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
        if (collision.CompareTag("TNT")) {
            collision.GetComponent<TNT>().explode();
        }
        Destroy(gameObject);
    }
}
