using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeTrail : MonoBehaviour
{
    [SerializeField]
    private float Duration;
    [SerializeField]
    private float FadeDelay;

    private SpriteRenderer spriteRenderer;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= FadeDelay)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1.0f - (time - FadeDelay) / Duration);
        }
        else if (time >= FadeDelay + Duration)
        {
            Destroy(gameObject);
        }
    }
}
