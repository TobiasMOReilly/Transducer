using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Main Menu Begin Button
    public void BeginGame()
    {
        SceneManager.LoadScene("Level01");
    }

    //Retrun to main Menu
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    //Return to main menu in time
    public void ReturnToMainMenu(float time)
    {
        Invoke("ReturnToMainMenu", time);
    }
}
