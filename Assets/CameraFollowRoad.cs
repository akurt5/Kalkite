using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowRoad : MonoBehaviour 
{
    public Transform PrevPos, NextPos;
    int CurrentRoadSeg = 0;
    public float travelT = 0;
    public float cameraSpeed = 2;

    void Start () 
	{
        PrevPos = transform;
        NextPos = RoadController.Road[CurrentRoadSeg].transform;
        CurrentRoadSeg++;
	}
	
	void Update () 
	{
        if (RoadController.Road.Count > CurrentRoadSeg + 1)
        {
            if (Vector3.Distance(transform.position, NextPos.position) <= 0.0001f)
            {
                PrevPos = NextPos;
                NextPos = RoadController.Road[CurrentRoadSeg].transform;
                CurrentRoadSeg++;
                travelT -= 1;
            }
        }
        else
        {
            RoadController.SpawnSegment();
            CurrentRoadSeg--;
            //RoadController.Road.RemoveAt(0);
        }
        travelT += Time.deltaTime / cameraSpeed;
        transform.position = Vector3.Lerp(PrevPos.position, NextPos.position, travelT);

        if (travelT < 0.1f)
        {
            travelT = 0.1f;
        }
	}
}
