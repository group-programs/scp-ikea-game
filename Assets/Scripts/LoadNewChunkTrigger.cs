using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewChunkTrigger : MonoBehaviour
{
    [Tooltip("Distance from the player when a new neighboring chunk will load.")]
    [Range(0f, 100f)]
    public float loadNextChunkDistance;
    private float chunkSize;
    private Transform currentChunk;

    void Awake()
    {
        chunkSize = GameObject.FindGameObjectWithTag("Map").GetComponent<WorldChunkGenerator>().tileSize.x;
    }
    
    void Update() 
    {
        if (currentChunk) {
            LoadNextChunkCheck(currentChunk);
        }
    }

    void OnTriggerEnter(Collider collider) 
    {
        if (collider.tag != "Chunk") return;
        if (currentChunk == collider.transform) return;
        Debug.Log("Found current chunk");
        currentChunk = collider.transform;
    }

    protected void LoadNextChunkCheck(Transform currentChunk) 
    {
        Vector3[] triggers = new[] {
            new Vector3(transform.position.x + loadNextChunkDistance, 0f,
                        transform.position.z + loadNextChunkDistance),
            new Vector3(transform.position.x - loadNextChunkDistance, 0f,
                        transform.position.z + loadNextChunkDistance),
            new Vector3(transform.position.x - loadNextChunkDistance, 0f,
                        transform.position.z - loadNextChunkDistance),
            new Vector3(transform.position.x + loadNextChunkDistance, 0f,
                        transform.position.z - loadNextChunkDistance)
        };
        foreach (Vector3 trigger in triggers) {
            
        }
    }
}
