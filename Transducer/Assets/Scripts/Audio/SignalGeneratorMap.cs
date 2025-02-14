using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalGeneratorMap : MonoBehaviour {

	public float frequnecy {get; set;}
	private double increment;
	private double phase;
	private double phaseOffset;

	private double sample_frequnecy = 48000.0;
	private float gain{get; set;}

	private GameObject global;
	private WinLose wl;

	void Start()
	{
		GetComponents ();

		frequnecy = 440.0f;
		gain = 0.1f;

		phaseOffset = 10;
		phase = phaseOffset;
		//pass gate vars to winlose script
		wl.gateSine = frequnecy;
		wl.gatePhase = phaseOffset;
	}

	//set up sine to play
	private void OnAudioFilterRead(float [] data, int channels)
	{
		increment = frequnecy * 2.0 * Mathf.PI / sample_frequnecy;

		for(int i=0; i<data.Length; i+=channels)
		{
			phase += increment;
			data [i] = (float)(gain * Mathf.Sin ((float)phase));
			if (channels == 2)
				data[i + 1] = data[i];
			if (phase > (Mathf.PI * 2))
				phase = 0.0;
		}
	}
		
	//get Components
	private void GetComponents()
	{
		global = GameObject.FindGameObjectWithTag ("GlobalScripts");
		wl = global.GetComponent<WinLose>();
	}

    //set gain amount
    public void SetGain(float amount)
    {
        gain = amount;
    }
}
