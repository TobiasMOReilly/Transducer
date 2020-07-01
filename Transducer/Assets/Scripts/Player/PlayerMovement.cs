using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Animator an;
    private Rigidbody2D rb;

    private float speed = 80f;

	private GameObject ampKnob;
	private KnobAmplitude ka;

	public GameObject[] playerUI = new GameObject[3];

    // Use this for initialization
    void Start () {
		
        GetComponents();
		BuildPlayerUI ();
    }
	
	void FixedUpdate () {
        Move();
		ShowUI ();
    }

    //Check for key press and move
    private void Move()
    {
        //Move EAST 
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector2.left * speed);
        //Move WEST
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector2.right * speed);
        //Move NORTH
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector2.up * speed);
        //Move SOUTH
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector2.down * speed);


    }
	//Activte the ui
	void ShowUI()
	{
		if (Input.GetKey (KeyCode.Tab)) {
			foreach (GameObject ob in playerUI)
				ob.SetActive (true);
		} 
		else 
		{
			foreach (GameObject ob in playerUI)
				ob.SetActive (false);
		}
	}

	//On entering a trigger set the current location
	void OnTriggerEnter2D(Collider2D other)
	{
		print ("TRIGGERED");
		ka.SetInZone(true);

		if (other.gameObject.tag == "ZoneAmp")
		{
			ka.SetCurrentZone("ZoneAmp");
			print ("ZoneAmp");
		}
		if (other.gameObject.tag == "ZoneSine")
		{
			print ("ZoneSine");
			ka.SetCurrentZone("ZoneSine");
		}
		if (other.gameObject.tag == "ZonePhase")
		{
			print ("ZonePhase");
			ka.SetCurrentZone("ZonePhase");
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		ka.SetInZone(false);
	}

	//get the needed components
    void GetComponents()
    {
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
		ampKnob = GameObject.FindGameObjectWithTag("KnobAmp");
		ka = ampKnob.GetComponent<KnobAmplitude> ();
    }

	//Find and add player ui game objects to the ui array
	void BuildPlayerUI()
	{
		playerUI [0] = GameObject.FindGameObjectWithTag ("KnobAmp");
		playerUI [1] = GameObject.FindGameObjectWithTag ("WavePlayer");
		playerUI [2] = GameObject.FindGameObjectWithTag ("SliderPhase");
	}
}
