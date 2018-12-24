using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrassSegment : Segment
{
    public static PerlinControlledNumber GrassHeight = new PerlinControlledNumber();
    public GrassSegment PrevGrass;

    public static float MaxGrassHeightDiff = 8;
    public static float grassWidth = 25;

    static int LeftRightTerrainOffset = 50;

    void Awake()
    {
        GrassHeight.SetOffset();

        if (PrevGrass != null)
        {
            GetComponent<MeshFilter>().mesh.vertices[2].y = PrevGrass.Vertices[0].y;
        }
        //GetComponent<MeshFilter>().mesh.vertices[1].y = Mathf.Lerp(-MaxGrassHeightDiff, MaxGrassHeightDiff, GrassL.Value);
    }

    public static float GetHeightVal(bool _Custom = false, Vector2 _CustomOffset = new Vector2())
    {
        if(_CustomOffset == new Vector2())
        {
            _CustomOffset = new Vector2(0, LeftRightTerrainOffset);
        }
        if(!_Custom)
        {
            return Mathf.Lerp(-MaxGrassHeightDiff, MaxGrassHeightDiff, GrassHeight.Value);
        }
        else
        {
            return Mathf.Lerp(-MaxGrassHeightDiff, MaxGrassHeightDiff, GrassHeight.CalcCustomVal(_CustomOffset));
        }
    }
}
