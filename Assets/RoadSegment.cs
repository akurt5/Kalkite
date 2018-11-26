using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class RoadSegment : MonoBehaviour 
{
    MeshFilter meshFilter;
    Vector3[] vertices = new Vector3[4];
    Vector3[] normals = new Vector3[4];
    Vector2[] uv = new Vector2[4];
    Mesh mesh;
    public Material RoadMaterial;
    public Material GrassMaterial;

    public Vector3 SegmentEndPos;

    public void Start()
    {
        //CreateRoadSegment(5f, 5f);
    }

    public void CreateRoadSegment(float _Width, float _Height)
    {
        CreateRoadSegment(new Vector2(_Width, _Height));
    }
    public void CreateRoadSegment(Vector2 _Dimensions)
    {
        meshFilter = GetComponent<MeshFilter>();
        GetComponent<MeshRenderer>().material = RoadMaterial;

        mesh = new Mesh();
        meshFilter.mesh = mesh;

        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(_Dimensions.x, 0, 0);
        vertices[2] = new Vector3(0, 0,_Dimensions.y);
        vertices[3] = new Vector3(_Dimensions.x, 0, _Dimensions.y);

        SegmentEndPos = new Vector3(0, 0, _Dimensions.y);

        mesh.vertices = vertices;

        int[] tri = new int[6];

        tri[0] = 0;
        tri[1] = 2;
        tri[2] = 1;

        tri[3] = 2;
        tri[4] = 3;
        tri[5] = 1;

        mesh.triangles = tri;

        normals[0] = -Vector3.forward;
        normals[1] = -Vector3.forward;
        normals[2] = -Vector3.forward;
        normals[3] = -Vector3.forward;

        mesh.normals = normals;

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 0);
        uv[2] = new Vector2(0, 0);
        uv[3] = new Vector2(0, 0);

        mesh.uv = uv;

        /*Debug.Log(mesh);
        Debug.Log(mesh.vertices);
        Debug.Log(mesh.triangles);*/

        GetComponent<MeshRenderer>().materials[0].color = Random.ColorHSV();
        //CreateSideSegments(_Dimensions);
    }

    public void CreateSideSegments(Vector2 _Dimensions)
    {
        GameObject leftSide = new GameObject("Left Road Side");
        meshFilter.gameObject.transform.parent = transform;
        meshFilter = leftSide.AddComponent<MeshFilter>();
        leftSide.AddComponent<MeshRenderer>().material = GrassMaterial;

        mesh = new Mesh();
        meshFilter.mesh = mesh;

        vertices[0] = new Vector3(-_Dimensions.x, 0, 0);
        vertices[1] = new Vector3(0, 0, 0);
        vertices[2] = new Vector3(-_Dimensions.x, 0, _Dimensions.y);
        vertices[3] = new Vector3(0, 0, _Dimensions.y);

        //SegmentEndPos = new Vector3(0, 0, _Dimensions.y);

        mesh.vertices = vertices;

        int[] tri = new int[6];

        tri[0] = 0;
        tri[1] = 2;
        tri[2] = 1;

        tri[3] = 2;
        tri[4] = 3;
        tri[5] = 1;

        mesh.triangles = tri;

        normals[0] = -Vector3.forward;
        normals[1] = -Vector3.forward;
        normals[2] = -Vector3.forward;
        normals[3] = -Vector3.forward;

        mesh.normals = normals;

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 0);
        uv[2] = new Vector2(0, 0);
        uv[3] = new Vector2(0, 0);

        mesh.uv = uv;

        /*Debug.Log(mesh);
        Debug.Log(mesh.vertices);
        Debug.Log(mesh.triangles);*/

        GetComponent<MeshRenderer>().materials[0].color = Random.ColorHSV(100, 140, 0.77f, 0.87f, 0.8f, 0.85f);
    }

    private void OnDestroy()
    {
        RoadController.Road.Remove(this);
    }
}
