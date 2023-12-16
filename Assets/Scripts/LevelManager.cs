using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> SegmentPrefabs;
    [SerializeField]
    private Vector3 SpawnPosition;
    [SerializeField]
    private GameObject SpawnHitbox;
    [SerializeField]
    private GameObject DestroyHitbox;
    [SerializeField]
    private float SegmentSpeed = 0.1f;


    private List<GameObject> SpawnedSegments = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        SpawnSegment();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        foreach (GameObject segment in SpawnedSegments) 
        {
            segment.transform.position += Vector3.left * SegmentSpeed;
        }
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
}
