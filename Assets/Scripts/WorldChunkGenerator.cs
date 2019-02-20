using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChunkGenerator : MonoBehaviour
{
    public Transform tilePrefab;
    public Transform mapholder;
    public Vector2 mapSize;
    public Vector2 tileSize;
    [Range(0,1)]
    public float outLinePercent;

    void Start() {
        GenerateMap();
    }

    public void GenerateMap() 
    {
        mapholder.localPosition = Vector3.zero;
        BoxCollider floorCollider = mapholder.gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        floorCollider.size = new Vector3(mapSize.x * tileSize.x, 0.1f, mapSize.y * tileSize.y);
        
        for (int x = 0; x < mapSize.x; x++) {
            for (int y = 0; y < mapSize.y; y++) {
                Vector3 tilePosition = new Vector3((-mapSize.x/2 + 0.5f + x)*tileSize.x, 0,(-mapSize.y/2 + 0.5f + y)*tileSize.y);
                Transform newTile = Instantiate(tilePrefab, Vector3.zero, Quaternion.Euler(Vector3.right * 90), mapholder) as Transform;
                newTile.localPosition = tilePosition;
                newTile.localScale = new Vector3(tileSize.x * (1 - outLinePercent), tileSize.y * (1 - outLinePercent), 1);
                
            }
        }
    }
}
