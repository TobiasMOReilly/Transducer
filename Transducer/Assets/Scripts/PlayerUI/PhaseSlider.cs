using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseSlider : MonoBehaviour {

    public string currentZone { get; set; }
    public bool inZone { get; set; }
    private float storedPhase { get; set; }

    private Slider phaseSlider;
    private GameObject ampKnob;
    private GameObject playerWave;
    private KnobAmplitude ka;
    private SignalGeneratorPlayer sgp;

    // Use this for initialization
    void Start () {
        GetComponents();
        currentZone = "";
        inZone = false;
	}

    void Update()
    {
        if (currentZone.Equals("ZonePhase") && inZone && ka.GetStoredAmp() > 0)
            phaseSlider.interactable = true;
        else
            phaseSlider.interactable = false;
    }

    //Method for slider UI
    public void SetPhase(float phaseIn)
    {
        storedPhase = phaseIn;
        sgp.SetPhase(storedPhase);
        ka.DecAmp(5);
    }

    void GetComponents()
    {
        phaseSlider = GetComponent<Slider>();
        ampKnob = GameObject.FindGameObjectWithTag("KnobAmp");
        ka = ampKnob.GetComponent<KnobAmplitude>();
        playerWave = GameObject.FindGameObjectWithTag("WavePlayer");
        sgp = playerWave.GetComponent<SignalGeneratorPlayer>();
    }
}
