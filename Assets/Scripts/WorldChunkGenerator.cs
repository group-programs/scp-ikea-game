using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChunkGenerator : MonoBehaviour
{
    public Transform tilePrefab;
    public Vector2 mapSize;
    public Vector2 tileSize;
    [Range(0,1)]
    public float outLinePercent;

    void Start() {
        GenerateMap();
    }

    public void GenerateMap() {

        string HolderName = "Generated Map";
        if (transform.Find(HolderName)) {
            DestroyImmediate(transform.Find(HolderName).gameObject);
        }
        Transform mapHolder = new GameObject(HolderName).transform;
        mapHolder.parent = transform;

        for (int x = 0; x < mapSize.x; x++) {
            for (int y = 0; y < mapSize.y; y++) {
                Vector3 tilePosition = new Vector3((-mapSize.x/2 + 0.5f + x)*tileSize.x, 0,(-mapSize.y/2 + 0.5f + y)*tileSize.y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90), mapHolder.transform) as Transform;
                newTile.localScale = new Vector3(tileSize.x * (1 - outLinePercent), tileSize.y * (1 - outLinePercent), 1);
                
            }
        }
    }
}
