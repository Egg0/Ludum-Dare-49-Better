using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryPanel : MonoBehaviour
{
    public BoolSO victory;
    private CanvasGroup canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        canvas.alpha = 0;
        victory.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (victory.active)
        {
            canvas.alpha = 1;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
