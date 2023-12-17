using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    private int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("UpdateTimer", 1f);
    }

    void UpdateTimer()
    {
        time++;
        TimeSpan ts = TimeSpan.FromSeconds(time);
        text.text = ts.ToString(@"m\:ss");
        Invoke("UpdateTimer", 1f);
    }
}
