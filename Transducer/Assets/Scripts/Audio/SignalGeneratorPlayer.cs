using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalGeneratorPlayer : MonoBehaviour {

	private float frequnecy = 0f;
	private double increment;

	private double phase;

	private double sample_frequnecy = 48000.0;
	private float gain = 0.1f;

	private GameObject global;
	private WinLose wl;

	void Start()
	{
		GetComponents();
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
		
	//Set the frequency
	public void SetFrequency(float freq)
	{
		frequnecy = freq;
		wl.playerSine = frequnecy;
	}
	//Set the gain
	public void SetGain(float gainIn)
	{
		gain = gainIn;
	}
	//Set phase amount
	public void SetPhase(float phaseIn)
	{
		phase = phaseIn;
		wl.playerPhase = phaseIn;
	}

	//Get the needed components
	private void GetComponents()
	{
		global = GameObject.FindGameObjectWithTag ("GlobalScripts");
		wl = global.GetComponent<WinLose>();
	}
}
