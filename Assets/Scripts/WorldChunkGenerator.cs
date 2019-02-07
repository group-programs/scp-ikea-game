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
        mapHolder.parent = this.transform;
        mapHolder.localPosition = Vector3.zero;
        BoxCollider floorCollider = mapHolder.gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        floorCollider.size = new Vector3(mapSize.x * tileSize.x, 0.1f, mapSize.y * tileSize.y);
        
        for (int x = 0; x < mapSize.x; x++) {
            for (int y = 0; y < mapSize.y; y++) {
                Vector3 tilePosition = new Vector3((-mapSize.x/2 + 0.5f + x)*tileSize.x, 0,(-mapSize.y/2 + 0.5f + y)*tileSize.y);
                Transform newTile = Instantiate(tilePrefab, Vector3.zero, Quaternion.Euler(Vector3.right * 90), mapHolder) as Transform;
                newTile.localPosition = tilePosition;
                newTile.localScale = new Vector3(tileSize.x * (1 - outLinePercent), tileSize.y * (1 - outLinePercent), 1);
                
            }
        }
    }
}
