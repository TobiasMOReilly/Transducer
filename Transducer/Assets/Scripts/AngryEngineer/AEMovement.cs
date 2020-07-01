using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AEMovement : MonoBehaviour {

    public Transform[] points;
    public LayerMask mask;

    private int currentPos;
    private float speed {get;set;}
    private float minSpeed = 2;

    private int currentPoint = -1;

	private GameObject player;
    private GameObject ampKnob;
    private KnobAmplitude ka;

    // Use this for initialization
    void Start()
    {
		player = GameObject.FindGameObjectWithTag ("Player");
        ampKnob = GameObject.FindGameObjectWithTag("KnobAmp");
        ka = ampKnob.GetComponent<KnobAmplitude>();

        speed = minSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        SetSpeed();
        RayCasting();
        Move();
    }

    //Raycasting, if player is in field of view, move towards. 
    private void RayCasting()
    {
        float rayLength =5f;

		Vector2 playerPos = player.transform.position;
		Vector2 direction;
		Vector2 playerDirection = playerPos - (Vector2)transform.position;

		//if at the last point, return to start
		if(currentPoint ==  points.Length - 1)
        	direction = points[0].position - transform.position;
		//else continue through points
		else
			direction = points[currentPoint+1 ].position - transform.position;

		//Get the angle between the player and the engineer
		float angle = Vector3.Angle (player.transform.position, direction);
		//Get the distance between player and engineer
		float dist = Vector3.Distance (player.transform.position, transform.position);

		// if within field of view, move towards
		if (angle < 90f && dist < 5f) 
		{
			//print ("In Sight");

			RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDirection, rayLength, mask);

			if (hit && hit.transform.name == "Player") {
				//print ("Hit " + hit.transform.name);
				moveToPlayer ();
			}
		}

		//Debug.DrawRay(transform.position, direction , Color.magenta, 0.01f);
    }

	//Move to the player
	private void moveToPlayer()
	{
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
	}

    //Find the closest patrol point
    private int FindClosestPoint()
    {
        float smallestDist = Vector3.Distance(transform.position, points[0].position);
        int shortest = 0;

        for (int i = 0; i < points.Length; i++)
            if (Vector3.Distance(transform.position, points[i].position) < smallestDist)
            {
                smallestDist = Vector3.Distance(transform.position, points[i].position);
                shortest = i;
            }
        return shortest;
    }

    //Move 
    private void Move()
    {
        //Move to closest point if not on a pre set location
        if (currentPoint == -1)
        {
           // print("Going to Point 0");
            transform.position = Vector3.MoveTowards(transform.position, points[FindClosestPoint()].position, speed * Time.deltaTime);
            if (HasArrived())
                currentPoint = GetCurrentPoint();
        }
        //if at the last point got to first point
        else if(currentPoint == points.Length - 1)
        {
            //print("Going to Point 0 again");
            transform.position = Vector3.MoveTowards(transform.position, points[0].position, speed * Time.deltaTime);
            if (HasArrived())
                currentPoint = GetCurrentPoint();
        }
        else
        {
           // print("Going to Point: " + (currentPoint +1));
            transform.position = Vector3.MoveTowards(transform.position, points[currentPoint+1].position, speed * Time.deltaTime);
            if (HasArrived())
                currentPoint = GetCurrentPoint();
        }
    }

    //check and return current point
    private int GetCurrentPoint()
    {
        int currentPoint = -1;

        for(int i = 0; i < points.Length; i++)
        {
            if (transform.position == points[i].position)
            {
                currentPoint = i;
                break;
            }
            else
                currentPoint = -1;
        }

        return currentPoint;
    }

    //Check if arrived at destination
    private bool HasArrived()
    {
        bool arrived = false;
        //if at the last point
        if (currentPoint == points.Length -1)
        {
            if (transform.position == points[0].position)
                arrived = true;
        }
        else if (transform.position == points[currentPoint + 1].position)
            arrived = true;

        return arrived;
    }

    //Set movement speed based on players stored amplitude
    private void SetSpeed()
    {
        if (speed < minSpeed)
            speed = 2;
        else
            speed = ka.GetAmp()/2;
    }
}
