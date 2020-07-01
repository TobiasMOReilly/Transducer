using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLose : MonoBehaviour {

	public bool gamelose { get; set;}
	public bool gameWin{ get; set;}

	public float playerSine{ get; set;}
	public double playerPhase{ get; set;} //phaseOffset var

	public float gateSine{ get; set;}
	public double gatePhase{ get; set;} //phaseOffset var

    public float amplitude { get; set; }

    public GameObject winMessage;
    public GameObject loseMessage;

    private GameObject gate;
    private GameObject gateCollider;
    private GameObject arrow;
    private Arrows arrows;
    private SignalGeneratorMap sgm;
    private SceneControl sc;

	// Use this for initialization
	void Start () {
        gate = GameObject.FindGameObjectWithTag("MapGate");
        sgm = gate.GetComponent<SignalGeneratorMap>();
        gateCollider = GameObject.FindGameObjectWithTag("GateCollider");
        sc = GetComponent<SceneControl>();
        arrow = GameObject.FindGameObjectWithTag("ExitArrows");
        arrows = arrow.GetComponent<Arrows>();
    }
	
	// Update is called once per frame
	void Update () {

        CheckGatesMatch();//should be checked else where.... no need to check every frame
        CheckAmplitude();
        if (gameWin)
        {
            winMessage.SetActive(true);
            sgm.SetGain(0);
            gateCollider.GetComponent<Collider2D>().isTrigger =true;
            arrows.SetFlashOn();
        }
        else if (gamelose)
        {
            loseMessage.SetActive(true);
            sc.ReturnToMainMenu(3f);
        }
    }

	//check if both waves match
	void CheckGatesMatch()
	{
		bool sineEqual = false;
		bool phaseEqual = false;

		if (playerSine >= gateSine)
			sineEqual = true;
		if (playerPhase >= gatePhase)
			phaseEqual = true;

		if (sineEqual && phaseEqual)
			gameWin = true;
	}
    //Check AMplitude level
    private void CheckAmplitude()
    {
		if (amplitude <= 0)
			gamelose = true;
    }
}
