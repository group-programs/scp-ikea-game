using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public Transform chunkTiles;
    private float[] noiseValues;
    private GameObject[] rooms;

    void Awake() {
        rooms = Resources.LoadAll<GameObject>("Rooms");        
    }

    public void GenerateChunk(float randomSeed, Transform tile)
    {
        randomSeed = randomSeed*10000000;
    
        //This will place as many rooms as possible (of the same size) next to each other
        //inside of a chunk of any given size: WorldChunkGenerator -> Tile Size field
        Transform newRoom;
        Vector2 roomsPerTile = new Vector2( Mathf.Floor(tile.localScale.x / rooms[0].transform.localScale.x),
                                            Mathf.Floor(tile.localScale.y / rooms[0].transform.localScale.y));
        //This assumes rooms are square
        float roomPlacementOffset = rooms[0].transform.localScale.x; 
        Vector2 firstPlacementPosition = new Vector2(tile.position.x + (tile.localScale.x / 2) - (roomPlacementOffset / 2), 
                                                     tile.position.z + (tile.localScale.y / 2) - (roomPlacementOffset / 2));
        
        for (int i = 0; i < roomsPerTile.x; i++) {
            for (int j = 0; j < roomsPerTile.y; j++) {
                Transform randRoom;
                if (Random.value > 0.5f) {
                    randRoom = rooms[0].transform;
                } else {
                    randRoom = rooms[1].transform;
                }
                newRoom = Instantiate(randRoom, 
                            new Vector3(
                                firstPlacementPosition.x - i * roomPlacementOffset, 
                                tile.position.y + 0.01f,
                                firstPlacementPosition.y - j * roomPlacementOffset), 
                            randRoom.transform.rotation).transform;
                newRoom.parent = tile;
            }
        }
    }
}