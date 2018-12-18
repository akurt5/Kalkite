using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrassSegment : Segment
{
    public static PerlinControlledNumber GrassL = new PerlinControlledNumber();
    public GrassSegment PrevGrass;

    public static float MaxGrassHeightDiff = 3;

    void Awake()
    {
        GrassL.SetOffset();

        if (PrevGrass != null)
        {
            GetComponent<MeshFilter>().mesh.vertices[2].y = PrevGrass.Vertices[0].y;
        }
        //GetComponent<MeshFilter>().mesh.vertices[1].y = Mathf.Lerp(-MaxGrassHeightDiff, MaxGrassHeightDiff, GrassL.Value);
    }

    public static float GetHeightVal()
    {
        return Mathf.Lerp(-MaxGrassHeightDiff, MaxGrassHeightDiff, GrassL.Value);
    }
}
