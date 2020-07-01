using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KnobAmplitude : MonoBehaviour {

	private GameObject playerWave;
	private SignalGeneratorPlayer sgp;
    private GameObject ampMeter;
    private AmpMeter am;
    private GameObject global;
    private WinLose wl;

	private string currentZone;
	private bool inZone = false;

    private float storedAmplitude;
	private float storedSine = 0;
	private float storedPhase = 0;

    private float maxAmplitude = 100;

    private float collectionRateAmp = 0.05f;
	private float collectionRateSine = 1f;
	private float collectionRatePhase = 0.1f;

    float startAngle = 0.0f;

    // Use this for initialization
    void Start () {
        storedAmplitude = 10;
        GetComponents ();
        //SetAmpMeter();
        wl.amplitude = storedAmplitude;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDrag()
    {
        //if in a collection zone
		if(inZone)
		{
        	RotateKnob();

            //if in amplitude collection zone
			if (currentZone.Equals ("ZoneAmp") && storedAmplitude <= maxAmplitude) {
				storedAmplitude += collectionRateAmp;
                SetAmpMeter();
                wl.amplitude = storedAmplitude;
                //print ("Amplitude: " + storedAmplitude);
            }
            //if in Sine wave collection zone
			else if (currentZone.Equals ("ZoneSine") && storedAmplitude > 0) {
				//current wave type gain++
				storedSine += collectionRateSine;
				//subtract the amount collected from stored amplitude
				storedAmplitude -= collectionRateAmp;
                SetAmpMeter();
                wl.amplitude = storedAmplitude;
                //set the frequency amount  in the sound generator
                sgp.SetFrequency (storedSine);

				//print ("Sine: " + storedSine + "|| Amp: " + storedAmplitude);
			}
            /**
			//If in the phase zone
			else if (currentZone.Equals ("ZonePhase") && storedAmplitude > 0)
			{
				//print ("Phase: " + storedPhase);
				//increase stored phase
				storedPhase += collectionRatePhase;
				//decrease amplitude
				storedAmplitude -= collectionRateAmp;
                SetAmpMeter();
                wl.amplitude = storedAmplitude;
                //set the phase amount
                sgp.SetPhase(storedPhase);
			}**/
		}
        //else disable
		

    }

	//rotate the knob
    void RotateKnob()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 vec = Input.mousePosition - screenPosition;

        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - startAngle, Vector3.forward);
    }

	//Set current zone
	public void SetCurrentZone(string zoneIn)
	{
		currentZone = zoneIn;
	}

	//Set inZone
	public void SetInZone(bool b)
	{
		inZone = b;
	}

    //Decrement stored Amplitude with multiplier
    public void DecAmp(float multiplier)
    {
        storedAmplitude -= collectionRateAmp * multiplier;
        SetAmpMeter();
        wl.amplitude = storedAmplitude;
    }
    //Send stored Amplitude to AmpMeter
    public void SetAmpMeter()
    {
        am.currAmp = storedAmplitude;
        am.SetAmpMeter();
    }

    //return stored amplitude
    public float GetStoredAmp()
    {
        return storedAmplitude;
    }
	void GetComponents()
	{
		playerWave = GameObject.FindGameObjectWithTag("WavePlayer");
		sgp = playerWave.GetComponent<SignalGeneratorPlayer>();
        ampMeter = GameObject.FindGameObjectWithTag("AmpMeter");
        if (ampMeter !=null)
            print("Got amp found");
        am = ampMeter.GetComponent<AmpMeter>();
        global = GameObject.FindGameObjectWithTag("GlobalScripts");
        wl = global.GetComponent<WinLose>();
	}
    //return stored amplitude
    public float GetAmp()
    {
        return storedAmplitude;
    }
}
