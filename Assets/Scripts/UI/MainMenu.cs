using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public CanvasGroup controlsPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC pressed, quitting");
            Application.Quit();
        }
    }

    public void ToggleControlsPanel()
    {
        if (controlsPanel.alpha == 0)
        {
            controlsPanel.alpha = 1;
        } else
        {
            controlsPanel.alpha = 0;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
