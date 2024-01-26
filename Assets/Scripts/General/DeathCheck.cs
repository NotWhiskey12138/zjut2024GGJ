using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCheck : MonoBehaviour
{
    [Header("Check Parameter")]
    public Vector2 bottomOffset;
    public float checkRaduis;
    public LayerMask deathLayer;
    public bool isDead;
    private void Update()
    {
        Check();
    }
    public void Check()
    {
        //ºÏ≤‚À¿Õˆ±ﬂΩÁ
        isDead = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(bottomOffset.x * transform.localScale.x, bottomOffset.y), checkRaduis, deathLayer);

    }
    private void OnDrawGizmosSelected()//ªÊ÷∆≈–∂®«¯”Ú
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + new Vector2(bottomOffset.x * transform.localScale.x, bottomOffset.y), checkRaduis);
    }
}
