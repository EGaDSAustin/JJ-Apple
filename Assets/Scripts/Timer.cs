using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int Time = 0;

    [SerializeField]
    private TextMeshProUGUI text;
    
    // Start is called before the first frame update
    public void Start()
    {
        Invoke("UpdateTimer", 1f);
    }

    void UpdateTimer()
    {
        Time++;
        UpdateText();
        Invoke("UpdateTimer", 1f);
    }

    public void UpdateText()
    {
        TimeSpan ts = TimeSpan.FromSeconds(Time);
        text.text = ts.ToString(@"m\:ss");
    }
}
