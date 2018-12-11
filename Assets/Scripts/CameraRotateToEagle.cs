using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateToEagle : MonoBehaviour 
{
	float lerpT = 0;
	float CameraRotateSecs = 1.5f;
	Quaternion OGRotation;
	public GameObject CurrentEagle;

	public float EaglePassDist = 5;
	
	public void OnEnable()
	{
		OGRotation = transform.rotation;
		lerpT = 0;
	}

	public void Update()
	{
		if(CurrentEagle.transform.position.z >= transform.position.z - EaglePassDist)
		{
			Transform tTrans = new GameObject().transform;
			tTrans.parent = transform;
			tTrans.position = transform.position;
			tTrans.rotation = transform.rotation;
			tTrans.LookAt(CurrentEagle.transform);
			tTrans.rotation = Quaternion.Euler(transform.eulerAngles.x, tTrans.eulerAngles.y, transform.eulerAngles.z);
			transform.rotation = tTrans.rotation;


			CurrentEagle.transform.LookAt(transform);

			Destroy(tTrans.gameObject);
		}
		else
		{
			transform.rotation = Quaternion.Lerp(transform.rotation, OGRotation, lerpT);
			lerpT += Time.deltaTime / CameraRotateSecs;
			if(lerpT >= 1)
			{

				transform.rotation = OGRotation;
				CurrentEagle = null;
				this.enabled = false;
			}
		}
	}
}
