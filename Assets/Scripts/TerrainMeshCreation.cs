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
        Mesh mesh = new Mesh();

        Vector3[] vertices = {
			new Vector3(0, 0, 0) + _Position,
			new Vector3(_Dimensions.x, 0, 0) + _Position,
			new Vector3(0, 0, _Dimensions.y) + _Position,
			new Vector3(_Dimensions.x, 0, _Dimensions.y) + _Position,
		};

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
