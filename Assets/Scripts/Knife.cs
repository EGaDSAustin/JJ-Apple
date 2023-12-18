using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField]
    private GameObject KnifeTrailPrefab;

    private Rigidbody2D rb;
    private BoxCollider2D col;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(SpawnKnifeTrailCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            var runner = collision.gameObject.GetComponent<PenguinRunner>();
            runner.Die();
        }

        col.enabled = false;
        StartCoroutine(DestroyKnife());
    }

    IEnumerator DestroyKnife()
    {
        for (int i = 0; i < 10; i++)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a * 0.9f);
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }

    IEnumerator SpawnKnifeTrailCoroutine()
    {
        Vector3 spawnPosition;
        Quaternion spawnRotation;
        while (true)
        {
            transform.GetPositionAndRotation(out spawnPosition, out spawnRotation);
            var kt = Instantiate(KnifeTrailPrefab, transform.parent);
            kt.transform.position = spawnPosition;
            kt.transform.rotation = spawnRotation;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
