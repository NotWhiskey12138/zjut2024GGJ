using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCheck : MonoBehaviour
{
    [Header("Check Parameter")]
    public Vector2 bottomOffset;
    public float checkRaduis;
    public LayerMask stageLayer;
    public bool isStage;
    private void Update()
    {
        Check();
    }
    public void Check()
    {
        //检测通关flag
        isStage = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(bottomOffset.x * transform.localScale.x, bottomOffset.y), checkRaduis, stageLayer);

    }
    private void OnDrawGizmosSelected()//绘制判定区域
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + new Vector2(bottomOffset.x * transform.localScale.x, bottomOffset.y), checkRaduis);
    }
}
