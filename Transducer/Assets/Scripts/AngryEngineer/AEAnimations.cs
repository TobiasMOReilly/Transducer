using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEAnimations : MonoBehaviour {

    private Animator an;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

      
	}
}
