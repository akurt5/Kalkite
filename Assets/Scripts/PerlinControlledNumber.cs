using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinControlledNumber
{
    public float Value
    {
        get { return CalcVal(); }
    }
    public float Offset;
    public float Resolution = 3f;
    public Vector2 Coords;
    public float x
    {
        get { return Coords.x; }
        set { Coords.x = value; }
    }
    public float y
    {
        get { return Coords.y; }
        set { Coords.y = value; }
    }

    public void ValueInc()
    {
        Coords.x++;
    }
    public void ValueDec()
    {
        Coords.x--;
    }
    float CalcVal()
    {
        ValueInc();
        //Debug.Log(Mathf.PerlinNoise(x + Offset / Resolution, y + Offset / Resolution));
        return Mathf.PerlinNoise(x + Offset / Resolution, y + Offset / Resolution);
    }
    public void SetOffset()
    {
        if(Offset == 0)
        {
            Offset = Random.Range(-99999, 99999);
        }
    }
}