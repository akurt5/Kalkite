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
    public float grassWidth = 5;
    void Start()
    {

        float PrevYL =  0;
        int PrevVert = -1;

        if(PrevGrass[0] != null)
        {
            PrevYL = PrevGrass[0].Vertices[2].y;
            PrevVert = 0;
        }

        grass[0] = Instantiate(GrassSegPrefab, transform.position, transform.rotation, transform).GetComponent<GrassSegment>();
        grass[0].CreateSegment(new Vector2(grassWidth, 5),new Vector3(-grassWidth, 0, 0), GrassSegment.GetHeightVal(), 2, PrevYL, PrevVert);
        grass[1] = Instantiate(GrassSegPrefab, transform.position, transform.rotation, transform).GetComponent<GrassSegment>();
        grass[1].CreateSegment(new Vector2(grassWidth, 5),new Vector3(Dimensions.x, 0, 0)/*, GrassSegment.GetHeightVal(), 3*/);

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
