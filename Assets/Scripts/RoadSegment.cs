using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class RoadSegment : Segment
{
    public static GrassSegment[] PrevGrass = new GrassSegment[2];
    public GameObject GrassSegPrefab;
    GrassSegment[] grass = new GrassSegment[2];
    void Start()
    {

        float PrevYL =  0;
        int PrevVertL = -1;

        if(PrevGrass[0] != null)
        {
            PrevYL = PrevGrass[0].Vertices[2].y;
            PrevVertL = 0;
        }

        float PrevYR =  0;
        int PrevVertR = -1;

        if(PrevGrass[0] != null)
        {
            PrevYR = PrevGrass[1].Vertices[3].y;
            PrevVertR = 1;
        }

        grass[0] = Instantiate(GrassSegPrefab, transform.position, transform.rotation, transform).GetComponent<GrassSegment>();
        grass[0].CreateSegment(new Vector2(GrassSegment.grassWidth, 5),new Vector3(-GrassSegment.grassWidth, 0, 0), GrassSegment.GetHeightVal(), 2, PrevYL, PrevVertL);
        grass[1] = Instantiate(GrassSegPrefab, transform.position, transform.rotation, transform).GetComponent<GrassSegment>();
        grass[1].CreateSegment(new Vector2(GrassSegment.grassWidth, 5),new Vector3(Dimensions.x, 0, 0), GrassSegment.GetHeightVal(true), 3, PrevYR, PrevVertR);

        grass[0].PrevGrass = PrevGrass[0];
        grass[1].PrevGrass = PrevGrass[1];
        PrevGrass[0] = grass[0];
        PrevGrass[1] = grass[1];

    }
    private void OnDestroy()
    {
        RoadController.Road.Remove(this);
    }
}
