using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
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
        offset = (offset + LevelManager.SegmentSpeed * Time.fixedDeltaTime / 2.0f) % 1.0f;
    }
}
