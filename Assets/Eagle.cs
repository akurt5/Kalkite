using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Animal 
{

    public override void Effect()
    {
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position);
    }

    private void Update()
    {
        
    }
}
