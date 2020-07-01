using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour {

    public  GameObject [] arrows;
    private GameObject arrowContain;

    private Color on;
    private Color off;

	// Use this for initialization
	void Start () {
        arrowContain = GameObject.FindGameObjectWithTag("ExitArrows");
        SetFlashOn();
    }

    //Set arrows on
    public void ArrowsOn()
    {
        arrowContain.SetActive(true);
    }

    public void SetFlashOn()
    {
        StartCoroutine(FlashArrows());
    }
    //Flash the arrows
    IEnumerator FlashArrows()
    {

        while (true)
        {
            foreach (GameObject arrow in arrows)
                arrow.SetActive(true);

            arrows[0].gameObject.SetActive(false);
            yield return new WaitForSeconds(1f);
            arrows[0].gameObject.SetActive(true);
            foreach (GameObject arrow in arrows)
                arrow.SetActive(false);
        }
    }
}
