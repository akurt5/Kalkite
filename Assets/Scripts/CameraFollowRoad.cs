using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowRoad : MonoBehaviour
{
    [HideInInspector]
    public Transform PrevPos, NextPos;  //Two locations to LERP between when following road; usually the PREV and NEXT segments of road;
    float travelT = 0;   //This T variable controls the LERP
    [Range(0.1f, 3f)]
    public float SetSpeedSecperRd = 0.6f;   //The *UsualSpeed* variable; How many Seonds to traverse a single segment of road.
    public float CurrentSpeedSecperRd;  //The *CurrentSpeed* variable; This is changed in game and sometimes reset to the *UsualSpeed* variable;
    [Range(1, 100)]
    public float SpeedIncreaseValue = 0.05f;   //The percentage of the *UsualSpeed* that we increase and decrease the *CurrentSpeed* by when accellerating and decellerating.
    [Range(1, 5)]
    public float AccellerationModifier = 2;
        [Range(1, 8)]
    public float DecellerationModifier = 4;
    [Range(0.2f, 1)]
    public float SpeedMax = 0.2f; //The maximum our *CurrentSPeed* variable can reach;
    [Range(0.5f, 5)]
    public float SpeedMin = 2f;  //The minimum our *CurrentSPeed* variable can reach;

    void Start()
    {
        /* Choose the prev and next points that our camera will lerp between */
        PrevPos = RoadController.Road[0].transform;
        NextPos = RoadController.Road[1].transform;

        /* set *CurrentSpeed* to *UsualSpeed* */
        CurrentSpeedSecperRd = SetSpeedSecperRd;
    }

    void Update()
    {
        /* The two functions that need to be Updated are checking player controls and controlling the cameras travel along the road */
        CheckPlayerInput();
        FollowRoad();
    }

    void FollowRoad()
    {
        /* check the distance between current position and the destination; Have we arrived? 
        if YES we need a new destination; the current destination becomes our previos point for the LERP
        next pos that we are lerping to is grabbed from the list of all roads as the previous +1
        we also decrement the travelT variable for the lerp to remain fluid. any remainder after the decrement is carried over into the next lerp and im actually not even sure if that works */
        if (Vector3.Distance(transform.position, NextPos.position) <= 0.001f)
        {
            PrevPos = NextPos;
            NextPos = RoadController.Road[RoadController.Road.IndexOf(PrevPos.GetComponent<RoadSegment>()) + 1].transform;
            travelT -= 1;
        }
        /* travelT is incremented by deltatime  / *CurrentSpeed*
        we then apply the lerped position to the cameras position to make the movement happen in the world game scenarion where it is currently running as a working, enabled game object with attached components running in real time and moving in the world. */
        travelT += Time.deltaTime / CurrentSpeedSecperRd;
        transform.position = Vector3.Lerp(PrevPos.position, NextPos.position, travelT);

        /* so it stays within the range of 0 and 1 we are doing things to the travelT variable */
        if (travelT < 0f)
        {
            travelT = 0f;
        }
    }
    void CheckPlayerInput()
    {
        /* if W is pressed we are decreasing the time taken for the car / camera to travel one segment of road
        if S is pressed we are increasing the time taken for the car / camera to travel one segment of road */
        if (Input.GetKey(KeyCode.W))
        {
            CurrentSpeedSecperRd -= Time.deltaTime * (SpeedIncreaseValue * AccellerationModifier);
        }
        if (Input.GetKey(KeyCode.S))
        {
            CurrentSpeedSecperRd += Time.deltaTime * (SpeedIncreaseValue * DecellerationModifier);
        }
        /* run speed correction software here to manage the speed appropriately after we have been manually modifying it */
        CorrectSpeed();
    }
    void CorrectSpeed()
    {
        /* Correting the speed.. we begin testing the W and S keys and the *CurrentSpeed*.
        No point in Correcting the speed if it is currently being modified, or if there is no changes to correct 
        When making changes we need to determin if the speed is too low or too high. then adjust accordingly.
        Im actually not sure this function can truly restore the speed variable to an equalibruim, I don't care*/
        if ((!Input.GetKey(KeyCode.W)) && (!Input.GetKey(KeyCode.S)) && (CurrentSpeedSecperRd != SetSpeedSecperRd))
        {
            if (CurrentSpeedSecperRd > SetSpeedSecperRd)
            {
                CurrentSpeedSecperRd -= Time.deltaTime * SpeedIncreaseValue;
            }
            else
            {
                CurrentSpeedSecperRd += Time.deltaTime * SpeedIncreaseValue;
            }
        }

        /* if the speed is being modified we need to restrict it to stay between the magic values, so clamp */
        CurrentSpeedSecperRd = Mathf.Clamp(CurrentSpeedSecperRd, SpeedMax, SpeedMin);
    }
}
