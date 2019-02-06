using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChunkGenerator : MonoBehaviour
{
    public Transform tilePrefab;
    public Vector2 mapSize;
    public Vector2 tileSize;

    void Start() {
        tilePrefab.transform.localScale = new Vector3(tileSize.x, tileSize.y, 1f);
        GenerateMap();
    }

    public void GenerateMap() {
        for (int x = 0; x < mapSize.x; x++) {
            for (int y = 0; y < mapSize.y; y++) {
                Vector3 tilePosition = new Vector3(-mapSize.x/2 + (0.5f*tileSize.x) + x*tileSize.x, 0, -mapSize.y/2 + (0.5f*tileSize.y) + y*tileSize.y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90), transform) as Transform;
            }
        }
    }
}
