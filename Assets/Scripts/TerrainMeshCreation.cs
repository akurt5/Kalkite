using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TerrainMeshCreation 
{
	public static Mesh CreateQuad(Vector2 _Dimensions)
    {
        return CreateQuad(_Dimensions, new Vector3(0, 0, 0));
    }
	public static Mesh CreateQuad(Vector2 _Dimensions, Vector3 _Position)
	{
        Vector3[] outTemp = new Vector3[4];
        return CreateQuad(_Dimensions, _Position, out outTemp);
    }
    public static Mesh CreateQuad(Vector2 _Dimensions, Vector3 _Position, out Vector3[] _Vertices)
    {
        return CreateQuad(_Dimensions, _Position, out _Vertices, 0, -1, 0, -1);
    }
    public static Mesh CreateQuad(Vector2 _Dimensions, Vector3 _Position, out Vector3[] _Vertices,  float _CornerVertexY, int _Vertex, float _OldVertPos, int _OldVert)
	{
        Mesh mesh = new Mesh();

        Vector3[] vertices = {
			new Vector3(0, 0, 0) + _Position,
			new Vector3(_Dimensions.x, 0, 0) + _Position,
			new Vector3(0, 0, _Dimensions.y) + _Position,
			new Vector3(_Dimensions.x, 0, _Dimensions.y) + _Position,
		};
        if(_Vertex != -1)
        {
            //Debug.Log(_CornerVertexY);
            vertices[_Vertex] = new Vector3(vertices[_Vertex].x, _CornerVertexY, vertices[_Vertex].z);
        }
        if(_OldVert != -1)
        {
            vertices[_OldVert] = new Vector3(vertices[_OldVert].x, _OldVertPos, vertices[_OldVert].z);
            
        }

        _Vertices = vertices;

        mesh.vertices = vertices;

        int[] tri = {
        0,
        2,
        1,

        2,
        3,
        1,
		};

        mesh.triangles = tri;

        Vector3[] normals = {
        -Vector3.forward,	//0
        -Vector3.forward,	//1
        -Vector3.forward,	//2
        -Vector3.forward,	//3
		};

        mesh.normals = normals;

        Vector2[] uv = {
			new Vector2(0, 0),	//0
			new Vector2(0, 0),	//1
			new Vector2(0, 0),	//2
			new Vector2(0, 0),	//3
		};

        mesh.uv = uv;

		return mesh;
	}

}
