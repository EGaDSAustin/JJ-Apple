using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static float SegmentSpeed;

    [SerializeField]
    private List<GameObject> SegmentPrefabs;
    [SerializeField]
    private Vector3 SpawnPosition;
    [SerializeField]
    private GameObject SpawnHitbox;
    [SerializeField]
    private GameObject DestroyHitbox;

    [SerializeField]
    private GameObject PlayerPrefab;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private Vector3 PlayerSpawnPosition;

    [SerializeField]
    private GameObject Seal;

    [SerializeField]
    private GameObject KnifePrefab;
    [SerializeField]
    private Vector3 KnifeSpawnPosition;

    [SerializeField]
    private Timer Timer;

    private SpriteRenderer playerRenderer;
    private List<GameObject> SpawnedSegments = new List<GameObject>();
    private List<GameObject> SpawnedKnives = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnSegment();
        playerRenderer = Player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        foreach (GameObject segment in SpawnedSegments) 
        {
            segment.transform.position += Vector3.left * SegmentSpeed * Time.fixedDeltaTime;
        }

        SegmentSpeed = 2.0f + Timer.Time / 10.0f;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.IsTouching(SpawnHitbox.GetComponent<Collider2D>()))
        {
            Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            if (collision.gameObject.CompareTag("EndSegment"))
            {
                SpawnSegment();
            }
        }
        else if (collision.IsTouching(DestroyHitbox.GetComponent<Collider2D>()))
        {
            if (collision.CompareTag("EndSegment"))
            {
                GameObject segment = collision.transform.parent.gameObject;
                SpawnedSegments.Remove(segment);
                Destroy(segment);
            }
            else if (collision.CompareTag("Player"))
            {
                Destroy(collision.gameObject);
            }
        }
    }

    void SpawnSegment() 
    { 
        int randIndex = Random.Range(0, SegmentPrefabs.Count);
        GameObject randSegmentPrefab = SegmentPrefabs[randIndex];
        GameObject segmentInstance = Instantiate(randSegmentPrefab, SpawnPosition, Quaternion.identity);
        SpawnedSegments.Add(segmentInstance);
    }

    // Removes segments to the left of destroy point
    void RemoveSegment(GameObject segment) 
    {
        Destroy(SpawnedSegments[0]);
        SpawnedSegments.RemoveAt(0);
    }

    public void SpawnKnife()
    {
        if (Player != null)
        {
            GameObject knife = Instantiate(KnifePrefab, KnifeSpawnPosition, Quaternion.identity);
            SpawnedKnives.Add(knife);

            Rigidbody2D rb = knife.GetComponentInChildren<Rigidbody2D>();
            rb.velocity = new Vector2((Player.transform.position.x - KnifeSpawnPosition.x) / 2.0f, 9.81f);
            rb.angularVelocity = -480.0f;
        }
    }

    public void Reset()
    {
        foreach (GameObject segment in SpawnedSegments)
        {
            Destroy(segment);
        }
        SpawnedSegments.Clear();

        foreach (GameObject knife in SpawnedKnives)
        {
            Destroy(knife);
        }
        SpawnedKnives.Clear();

        Destroy(Player);
        Player = Instantiate(PlayerPrefab, PlayerSpawnPosition, Quaternion.identity);

        Timer.CancelInvoke();
        Timer.Time = 0;
        Timer.UpdateText();
        Timer.Start();

        SpawnSegment();
    }
}
