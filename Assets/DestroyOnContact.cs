using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour 
{

    public static string destroyerLayerName = "Destroyer";

    private void Awake()
    {
        if (gameObject.name != "The Destroyer")
        {
            gameObject.AddComponent<BoxCollider>().isTrigger = true;
            
        }

        gameObject.layer = LayerMask.NameToLayer(destroyerLayerName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "The Destroyer")
        {
            Destroy(other.gameObject);
        }
    }
}
