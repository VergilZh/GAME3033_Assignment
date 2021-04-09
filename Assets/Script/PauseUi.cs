using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUi : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pausedUI;
    // Start is called before the first frame update
    void Start()
    {
        pausedUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Continue();
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                pausedUI.SetActive(true);
                Time.timeScale = 0f;
                gameIsPaused = true;
                Cursor.visible = true;
            }
        }
    }

    public void Continue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pausedUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.visible = false;
    }
}
