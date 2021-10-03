using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    bool isRunning;
    float currentTime;
    public int elapsedSeconds;
    public TextMeshProUGUI currentText;
    public BoolSO victory;

    // Start is called before the first frame update
    void Start()
    {
        isRunning = true;
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (victory != null && victory.active)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            currentTime = currentTime + Time.deltaTime;
            elapsedSeconds = (int)currentTime;
        }

        // HH:MM:SS
        List<int> timeValues = new List<int>();
        string displayString = "";
        int hours = (elapsedSeconds / 3600);
        int minutes = ((elapsedSeconds - (hours * 3600)) / 60);
        int seconds = (elapsedSeconds - (hours * 3600) - (minutes * 60));
        
        // Purposeful Ordering
        //timeValues.Add(hours);
        timeValues.Add(minutes);
        timeValues.Add(seconds);

        foreach (int timeValue in timeValues)
        {
            string displayValue = timeValue.ToString();
            // Prepend 0 to single digit values
            if (timeValue < 10)
            {
                displayValue = "0" + timeValue.ToString();
            }

            displayString = displayString + displayValue + ":";
        }

        displayString = displayString.Substring(0, displayString.Length - 1);
        currentText.text = displayString;
    }
    
    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
