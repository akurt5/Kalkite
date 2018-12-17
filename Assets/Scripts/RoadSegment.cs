using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class RoadSegment : Segment
{
    public GameObject GrassSegPrefab;
    GrassSegment[] grass = new GrassSegment[2];
    public float grassWidth = 5;
    void Start()
    {
        Debug.Log(Dimensions.x);
        grass[0] = Instantiate(GrassSegPrefab, transform.position, transform.rotation, transform).GetComponent<GrassSegment>();
        grass[0].CreateSegment(new Vector2(grassWidth, 5),new Vector3(-grassWidth, 0, 0));
        grass[1] = Instantiate(GrassSegPrefab, transform.position, transform.rotation, transform).GetComponent<GrassSegment>();
        grass[1].CreateSegment(new Vector2(grassWidth, 5),new Vector3(Dimensions.x, 0, 0));

    }
    private void OnDestroy()
    {
        RoadController.Road.Remove(this);
    }
}
