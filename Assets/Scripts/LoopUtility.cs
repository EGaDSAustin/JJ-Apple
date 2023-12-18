using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopUtility : MonoBehaviour
{
    [SerializeField]
    private AudioClip intro;
    [SerializeField]
    private AudioClip loop;
    [SerializeField]
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.timeSamples > intro.samples + loop.samples)
        {
            audioSource.timeSamples -= loop.samples;
        }
    }
}
