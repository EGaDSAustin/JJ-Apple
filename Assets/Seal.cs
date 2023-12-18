using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal : MonoBehaviour
{
    [SerializeField] float KnifeCooldown; // In seconds
    [SerializeField] LevelManager LevelManager;

    float knifeTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        knifeTime += Time.deltaTime;
        if (knifeTime >= KnifeCooldown)
        {
            LevelManager.SpawnKnife(transform.position);
            knifeTime = 0.0f;
        }
    }
}
