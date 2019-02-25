using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChunkGenerator : MonoBehaviour
{
    public int seed;
    public Transform tilePrefab;
    public Transform mapholder;
    private Vector2 mapSize = Vector2.one;
    public Vector2 tileSize;
    public Vector2 initialChunkPosition = Vector2.zero;

    [Range(0,1)]
    public float outLinePercent;

    private ChunkGenerator chunkGenerator;

    void Start() {
        chunkGenerator = gameObject.GetComponent<ChunkGenerator>();
        Random.seed = seed;
        CreateNewChunk(initialChunkPosition, Random.value);
    }

    public void CreateNewChunk(Vector2 chunkPosition, float seed) 
    {
        mapholder.localPosition = Vector3.zero;
        
        for (int x = 0; x < mapSize.x; x++) {
            for (int y = 0; y < mapSize.y; y++) {
                Vector3 tilePosition = new Vector3((-mapSize.x/2 + 0.5f + x)*tileSize.x + chunkPosition.x, 0,(-mapSize.y/2 + 0.5f + y)*tileSize.y + chunkPosition.y);
                Transform newTile = Instantiate(tilePrefab, Vector3.zero, Quaternion.Euler(Vector3.right * 90), mapholder) as Transform;
                newTile.localPosition = tilePosition;
                newTile.localScale = new Vector3(tileSize.x * (1 - outLinePercent), tileSize.y * (1 - outLinePercent), 1);
                newTile.name = "Chunk";
                BoxCollider floorCollider = newTile.gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
                floorCollider.size = new Vector3(1f, 1f, 0f);

                chunkGenerator.GenerateChunk(seed, newTile);
            }
        }
    }
}
