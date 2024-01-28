using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
    {
    public Button pause_button;
    public Button continue_button;
    public void PauseGame()
        {
        Time.timeScale = 1;
        }
    public void ContinueGame()
        {
        Time.timeScale = 0;
        }

    public void ReturnMenu() { SceneManager.LoadScene("ChooseMenu"); }

    public void debug_test1()
    {
        print("1 test button hello world!");
    }

    private void Start()
        {
        pause_button.onClick.AddListener(PauseGame);
        continue_button.onClick.AddListener(ContinueGame);
        }
    }
