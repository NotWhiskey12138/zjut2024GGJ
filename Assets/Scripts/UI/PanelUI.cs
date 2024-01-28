using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelUI : MonoBehaviour
    {
    public Button pause_button;
    public Button continue_button;
    public float animationSpeed;
    public AnimationCurve showCruve;
    public AnimationCurve hideCruve;
    public GameObject panel;
    public GameObject pause;

    public IEnumerator ShowPanel(GameObject gameObject, GameObject pause)//��ʾ���,���ذ�ť
        {
        float timer = 0;
        while (timer <= 1)
            {
            gameObject.transform.localScale = Vector3.one * showCruve.Evaluate(timer);
            pause.transform.localScale = Vector3.one * hideCruve.Evaluate(timer);
            timer += Time.deltaTime * animationSpeed;
            yield return null;
            }

        }
    public IEnumerator HidePanel(GameObject gameObject, GameObject pause)//�������,��ʾ��ť
        {
        float timer = 0;
        while (timer <= 1)
            {
            gameObject.transform.localScale = Vector3.one * hideCruve.Evaluate(timer);
            pause.transform.localScale = Vector3.one * showCruve.Evaluate(timer);
            timer += Time.deltaTime * animationSpeed;
            yield return null;
            }

        }

    public void debug_test_panel()
        {
        print("2 test button hello world!");
        }
    // Update is called once per frame

    public void hideSetting() { StartCoroutine(HidePanel(panel, pause)); debug_test_panel(); }
    public void showSetting() { StartCoroutine(ShowPanel(panel, pause)); debug_test_panel(); }

    
}
    /*
    //���麯�� �����ʾ �Ҽ�����
    private void Update()
        {
        if (Input.GetMouseButton(0))
            { StartCoroutine(ShowPanel(panel, pause)); }
        else if (Input.GetMouseButton(1))
            { StartCoroutine(HidePanel(panel, pause)); }
        }
    }
    */