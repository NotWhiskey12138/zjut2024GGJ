using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public Image img1;
    public Image img2;

    private void Update()
    {
        img1.sprite = PlayerController.Instance.GetItemImage();
        img2.sprite = PlayerTwoController.Instance.GetItemImage();
    }
}
