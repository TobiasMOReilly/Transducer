using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour {

    private Collider2D cd;
    private GameObject global;
    private WinLose wl;
    private SceneControl sc;

	// Use this for initialization
	void Start () {
        global = GameObject.FindGameObjectWithTag("GlobalScripts");
        wl = global.GetComponent<WinLose>();
        sc = global.GetComponent<SceneControl>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && wl.gameWin == true)
            sc.ReturnToMainMenu();
    }
}
