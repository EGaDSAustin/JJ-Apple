using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private float SegmentSpeed;

    private SpriteRenderer spriteRenderer;
    private float offset;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        spriteRenderer.material.mainTextureOffset = new Vector2(offset, 0.0f);
        offset = (offset + SegmentSpeed * Time.fixedDeltaTime) % 1.0f;
    }
}
