using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishedUI : MonoBehaviour
{
    public Button continue_button;
    public float animationSpeed;
    public AnimationCurve showCruve;
    public GameObject finishpanel;
    
    public IEnumerator ShowPanel(GameObject gameObject, GameObject pause)//��ʾ���,���ذ�ť
    {
        float timer = 0;
        while (timer <= 1)
        {
            gameObject.transform.localScale = Vector3.one * showCruve.Evaluate(timer);
            timer += Time.deltaTime * animationSpeed;
            yield return null;
        }

    }

    private void Update()
    {
        
    }
}
