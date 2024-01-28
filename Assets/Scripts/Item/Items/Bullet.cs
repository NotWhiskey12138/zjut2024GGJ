using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public  BoxCollider2D coll;
    

    public void setVelocity(Vector2 direction, float speed)
    {
        rb.velocity = direction * speed;
    }
 
    private bool shotFrom = true;//true == 1,false ==2;
    private Rigidbody2D rb;
  
    public void SetBullet(Vector2 direction, float speed, bool fromPlayer) {
        Debug.Log("set bullet execute");
        rb.velocity = direction * speed;
        shotFrom = fromPlayer;
        coll.enabled = true;
}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (shotFrom) {
            if (collision.CompareTag("player2"))
            {
                Debug.Log("shot from"+shotFrom);
                PlayerTwoController.Instance.PlayerDead();
            }
                }
        else {
            if (collision.CompareTag("player1"))

            {
                Debug.Log("shot from" + shotFrom);
                PlayerController.Instance.PlayerDead();
            }
        }
        
        Destroy(gameObject);
    }
}
