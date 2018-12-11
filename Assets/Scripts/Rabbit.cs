using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Animal
{
    Vector3 EndOfTheLine;
    public Vector2 RunTimeRange = new Vector2(5, 15);
    public float RabbitRunDist = 10;
    [Range(0.2f, 6)]
    public float RunSpeedSecs = 3;

    Vector3 StartPos;
    float lerpT;
    bool canRun = false;

    void Start()
    {
        StartPos = transform.position;
        EndOfTheLine = transform.position + (transform.forward * RabbitRunDist);
    }

    void OnTriggerEnter()
    {
        float TimeToRun = Random.Range(RunTimeRange.x, RunTimeRange.y);
        Invoke("Run", TimeToRun);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, EndOfTheLine) < 0.1f)
        {
            Destroy(gameObject);
        }

        if (canRun)
        {
            transform.position = Vector3.Lerp(StartPos, EndOfTheLine, lerpT);
            lerpT += Time.deltaTime / RunSpeedSecs;
        }
    }

    void Run()
    {
        canRun = true;
    }
}
