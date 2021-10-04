using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    public IntSO ammoCount;
    private CanvasGroup display;
    public TextMeshProUGUI text;

    private void Start()
    {
        display = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ammoCount.count > 0)
        {
            display.alpha = 1;
        } else
        {
            display.alpha = 0;
        }
        text.text = ammoCount.count.ToString();
    }
}
