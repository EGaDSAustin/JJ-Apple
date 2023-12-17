using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopUtility : MonoBehaviour
{

    [SerializeField]
    private AudioSource intro;
    [SerializeField]
    private AudioSource loop;
    // Start is called before the first frame update
    void Start()
    {
        intro.PlayScheduled(AudioSettings.dspTime + 0.25f);
        loop.PlayScheduled(AudioSettings.dspTime + 0.17f + intro.clip.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
