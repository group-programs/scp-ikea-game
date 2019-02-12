using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public int seed;
    private float[] noiseValues;

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
        Debug.Log("Chunk generated, seed: " + randomSeed*10000000);


    }
}
