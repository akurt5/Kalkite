using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{

    public static List<RoadSegment> Road = new List<RoadSegment>();
    public GameObject RoadSegPrefab;
    public Transform nextRoadPos;
    public static RoadController instance;
    GameObject MostRecentSegment;

    public GameObject AnimalPrefab;

    void Awake()
    {
        instance = this;
        SpawnSegment();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnSegment();   
        }
    }
    
    public static void SpawnSegment()
    {
        RoadSegment newSeg = Instantiate(instance.RoadSegPrefab, instance.nextRoadPos.position, instance.nextRoadPos.rotation, instance.transform).GetComponent<RoadSegment>();
        instance.MostRecentSegment = newSeg.gameObject;
        newSeg.CreateRoadSegment(2, 5);
        //newSeg.transform.parent = transform;
        Road.Add(newSeg);
        instance.nextRoadPos.position += newSeg.SegmentEndPos;
        if (Random.value > 0.8f)
        {
            SpawnAnimal();
        }
    }

    public static void SpawnAnimal()
    {
        GameObject Animal = Instantiate(instance.AnimalPrefab);
        Animal.transform.position = (Vector3.right * Random.Range(-0.7f, 1.7f)) + instance.MostRecentSegment.transform.position;
        Animal.transform.eulerAngles = new Vector3(Animal.transform.eulerAngles.x, Random.Range(0, 360), Animal.transform.eulerAngles.z);

    }
}