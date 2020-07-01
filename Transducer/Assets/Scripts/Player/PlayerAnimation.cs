using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator an;

	// Use this for initialization
	void Start () {
        an = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
     	//IDLE  
		if(Input.GetKeyUp(KeyCode.S))//SOUTH 
			an.SetInteger("AnimState", 0);
		else if(Input.GetKeyUp(KeyCode.A))//EAST
			an.SetInteger("AnimState", 1);
		else if(Input.GetKeyUp(KeyCode.D))//WEST
			an.SetInteger("AnimState", 2);
		else if(Input.GetKeyUp(KeyCode.W))//NORTH
			an.SetInteger("AnimState", 3);

		//Walking
		if(Input.GetKeyDown(KeyCode.S))//SOUTH
			an.SetInteger("AnimState", 4);
		if(Input.GetKeyDown(KeyCode.A))//EAST
			an.SetInteger("AnimState", 5);
		if(Input.GetKeyDown(KeyCode.D))//WEST
			an.SetInteger("AnimState", 6);
		if(Input.GetKeyDown(KeyCode.W))//NORTH
			an.SetInteger("AnimState", 7);
       /** 
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyUp(KeyCode.S))
            an.SetInteger("AnimState", 0);
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyUp(KeyCode.A))
            an.SetInteger("AnimState", 1);
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyUp(KeyCode.D))
            an.SetInteger("AnimState", 2);
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyUp(KeyCode.W))
            an.SetInteger("AnimState", 3);
    
        if (Input.GetKey(KeyCode.S))
            an.SetInteger("AnimState", 4);
        if (Input.GetKey(KeyCode.A))
            an.SetInteger("AnimState", 5);
        if (Input.GetKey(KeyCode.D))
            an.SetInteger("AnimState", 6);
        if (Input.GetKey(KeyCode.W))
            an.SetInteger("AnimState", 7);
	**/
    }
}
