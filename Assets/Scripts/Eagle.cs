using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Animal
{
    private void Start()
    {
        Camera.main.gameObject.GetComponent<CameraRotateToEagle>().enabled = true;
        Camera.main.gameObject.GetComponent<CameraRotateToEagle>().CurrentEagle = gameObject;
    }
}
