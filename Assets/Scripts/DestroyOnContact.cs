using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    [Range(1, 5)]
    int DestructionDelay = 3;
    public static string destroyerLayerName = "Destroyer";

    private void Awake()
    {
        if ((gameObject.name != "The Destroyer") && (gameObject.name != "Animal Activator"))
        {
            gameObject.AddComponent<BoxCollider>().isTrigger = true;

        }

        gameObject.layer = LayerMask.NameToLayer(destroyerLayerName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.name != "The Destroyer") && (other.gameObject.name != "Animal Activator"))
        {
            Destroy(other.gameObject, DestructionDelay);
        }
    }
}
