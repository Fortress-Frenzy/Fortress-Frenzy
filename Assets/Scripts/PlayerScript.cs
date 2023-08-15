using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class PlayerScript: MonoBehaviour {

    [SerializeField]
    private TMP_Text TimeText;
    public GameObject PauseUI;

    private bool ActivePausetUI = false;

    public InputActionReference toggleReference = null;

    void Update()
    {
        try
        {
            string ActualTime = GameObject.Find("Payload").GetComponent < PayloadScript > ().ActualTime;
            TimeText.text = "Time: " + ActualTime;
        }
        catch
        {
            TimeText.text = "Not In Game";
        }
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        DisplayPauseMenu();
    }

    public void DisplayPauseMenu()
    {
        if (ActivePausetUI)
        {
            PauseUI.SetActive(false);
            ActivePausetUI = false;
            Time.timeScale = 1;
        }
        else if (!ActivePausetUI)
        {
            PauseUI.SetActive(true);
            ActivePausetUI = true;
            Time.timeScale = 0;
        }
    }
}