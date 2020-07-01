using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalAnalyzer : MonoBehaviour {

	public float[] signalSamples;
	private int sampleAmount = 512;
	private AudioSource signal;

	private bool signalCollected = false;

	// Use this for initialization
	void Start () {

		signal = GetComponent<AudioSource>();
		signalSamples = new float[sampleAmount];

	}

	void Update()
	{
		StartCoroutine (populateSignalSamples2());
	}

	//populate signal sample array
	private void populateSignalSamples()
	{
		signal.GetOutputData(signalSamples, 0);
		signalCollected = true;
	}

	IEnumerator populateSignalSamples2()
	{
		signal.GetOutputData(signalSamples, 0);
		yield return new WaitForSeconds (10);
		signalCollected = true;
	}
}
