using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    private float[] noiseValues;
    void Start() {
        Random.seed = 42;
        noiseValues = new float[2];
        int i = 0;
        while (i < noiseValues.Length) {
            noiseValues[i] = Random.value;
            Debug.Log(noiseValues[i]);
            i++;
        }
    }
}
