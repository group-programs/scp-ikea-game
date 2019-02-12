using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public int seed;
    private float[] noiseValues;
    private GameObject[] rooms;

    void Awake() {
        rooms = Resources.LoadAll<GameObject>("Rooms");        
    }
    void Start() {
        Random.seed = seed;
        noiseValues = new float[2];
        int i = 0;
        while (i < noiseValues.Length) {
            GenerateChunk(Random.value);
            i++;
        }
    }
    public void GenerateChunk(float randomSeed)
    {
        randomSeed = randomSeed*10000000;
        Debug.Log("Chunk generated, seed: " + randomSeed);

        foreach (var room in rooms) {
            
        }
    }
}