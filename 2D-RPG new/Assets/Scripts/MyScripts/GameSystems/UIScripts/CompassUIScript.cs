using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassUIScript : MonoBehaviour
{
    bool isTrackingQuest,isWaypointActive;
    
    //Calculation Variables
    private float rotationZ;
    private Vector3 difference;

    //Objects
    public Transform questLocation, wayPointLocation, playerLocation;
    public Transform questPointerNeedle, wayPointerNeedle;   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //questMarker
        difference = questLocation.position - playerLocation.position;
        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        questPointerNeedle.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90.0f);

        //waypointMarker
        difference = wayPointLocation.position - playerLocation.position;
        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        wayPointerNeedle.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90.0f);


    }
}
