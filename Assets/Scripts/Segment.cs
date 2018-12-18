using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public abstract class Segment : MonoBehaviour
{
    public Material material;
    public Vector3 segmentEndPos;
    public Vector2 Dimensions;

    public Vector3[] Vertices = new Vector3[4];

    public virtual Segment CreateSegment(float _Width, float _Height)
    {
        return CreateSegment(new Vector2(_Width, _Height));
    }
    public virtual Segment CreateSegment(Vector2 _Dimensions)
    {
        return CreateSegment(_Dimensions, new Vector3(0, 0, 0));
    }
    /*public virtual Segment CreateSegment(Vector2 _Dimensions, Vector3 _Position)
    {
        Dimensions = _Dimensions;
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        GetComponent<MeshRenderer>().material = material;

        meshFilter.mesh = TerrainMeshCreation.CreateQuad(_Dimensions, _Position);

        segmentEndPos = new Vector3(0, 0, _Dimensions.y);

        return this;
    }*/
    public Segment CreateSegment(Vector2 _Dimensions, Vector3 _Position)
    {
        return CreateSegment(_Dimensions, _Position, 0, -1, 0, -1);
    }
    public Segment CreateSegment(Vector2 _Dimensions, Vector3 _Position, float _CornerVertexY, int _Vertex, float _OldVertPos, int _OldVert)
    {
        Dimensions = _Dimensions;
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        GetComponent<MeshRenderer>().material = material;

        meshFilter.mesh = TerrainMeshCreation.CreateQuad(_Dimensions, _Position, out Vertices, _CornerVertexY, _Vertex, _OldVertPos, _OldVert);

        segmentEndPos = new Vector3(0, 0, _Dimensions.y);

        return this;
    }
}
