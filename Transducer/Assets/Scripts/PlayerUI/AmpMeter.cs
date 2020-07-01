using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmpMeter : MonoBehaviour {

    public float maxAmp { get; set; }
    public float minAmp { get; set; }
    public float currAmp { get; set; }
    private float defaultAmp;
    private Slider ampMeter;

    void Start () {
        defaultAmp = 10;
        maxAmp = 100;
        minAmp = 0;
        currAmp = defaultAmp;
        ampMeter = GetComponent<Slider>();
        if (ampMeter == null)
            print("no meter");
        ampMeter.value = minAmp;
        SetAmpMeter();
    }

    //Set the slider to match amplitude stored
    public void SetAmpMeter()
    {
        ampMeter.value = currAmp;
    }

}
