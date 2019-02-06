using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor (typeof (WorldChunkGenerator))]
public class MapEditor : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        WorldChunkGenerator map = target as WorldChunkGenerator;

        map.GenerateMap();
    }
}
