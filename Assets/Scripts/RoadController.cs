using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{

    public static List<RoadSegment> Road = new List<RoadSegment>();
    public GameObject RoadSegPrefab;
    public GameObject GSegPrefab;
    public Transform nextRoadPos;
    public Transform nextGrassPos;
    public static RoadController instance;
    GameObject MostRecentSegment;

    PerlinControlledNumber RoadDirection = new PerlinControlledNumber();

    public int RoadLength = 40;
    public float EagleFreqSecs = 25;
    [Range(0, 1)]
    public float EagleSpawnChance = 0.2f;
    public GameObject EaglePrefab;
    public float Eagle2RdDist = 2.7f;

    public GameObject RabbitPrefab;
    public float RabbitFreqSecs = 0.1f;
    [Range(0, 1)]
    public float RabbitSpawnChance = 0.2f;
    public float Rabbit2RdDist = 3.5f;
    public GameObject AnimalPrefab;


    void Awake()
    {
        RoadDirection.SetOffset();
        instance = this;
        UpdateRoadCount();
        //InvokeRepeating("SpawnEagle", EagleFreqSecs, EagleFreqSecs);
        Invoke("SpawnEagle", EagleFreqSecs);
        InvokeRepeating("SpawnRabbit", RabbitFreqSecs, RabbitFreqSecs);
    }

    void Update()
    {
        UpdateRoadCount();
    }

    void UpdateRoadCount()
    {
        while (Road.Count < RoadLength)
        {
            SpawnSegment();
        }
    }

    public static void SpawnSegment()
    {
        RoadSegment newSeg = Instantiate(instance.RoadSegPrefab, instance.nextRoadPos.position, instance.nextRoadPos.rotation, instance.transform).GetComponent<RoadSegment>();
        instance.MostRecentSegment = newSeg.gameObject;
        newSeg.CreateSegment(2, 5);
        //newSeg.transform.parent = transform;
        Road.Add(newSeg);
        instance.nextRoadPos.position += newSeg.segmentEndPos;
        if (Random.value > 0.9f)
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

    public void SpawnEagle()
    {
        if (Random.value < EagleSpawnChance)
        {
            GameObject Eagle = Instantiate(EaglePrefab);
            Eagle.transform.position = (Vector3.right * Eagle2RdDist) + instance.MostRecentSegment.transform.position;
        }
    }

    public void SpawnRabbit()
    {
        if (Random.value < RabbitSpawnChance)
        {
            GameObject Rabbit = Instantiate(RabbitPrefab);
            float spawnDist;
            if(Random.value > 0.5)
            {
                spawnDist = -Rabbit2RdDist;
            }
            else
            {
                spawnDist = Rabbit2RdDist;
            }
            Rabbit.transform.position = (Vector3.right * spawnDist) + instance.MostRecentSegment.transform.position;

            if(spawnDist < 0)
            {
                Rabbit.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                Rabbit.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
    }

}