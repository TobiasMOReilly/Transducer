using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignalDraw : MonoBehaviour {

	public float refresh = 5f;

	private int height;
	private int width;
	private Color bgColor = Color.black;
	private Color wavColor = Color.green;

	private Color[] imageArray;
	public static Texture2D tex;

	private bool draw = false;

	private SignalAnalyzer sa;
	// Use this for initialization
	void Start () {
		sa = GetComponent<SignalAnalyzer> ();

		height = 200;
		width = 400;

		tex = new Texture2D (width, height);
		GetComponent<RawImage> ().texture = tex;

		imageArray = new Color[width * height];

		//set bg
		for(int i=0; i<imageArray.Length; i++)
			imageArray[i] = bgColor;
	}
	
	// Update is called once per frame
	void Update () {

		//if(!draw)
			StartCoroutine(DrawWave());

	}

	IEnumerator DrawWave()//PROBLEM SUCKS RESOURSES
	{
		while (true)
		{
			tex.SetPixels (imageArray, 0);

			for (int i = 0; i < sa.signalSamples.Length; i++) {
				tex.SetPixel ((int)(width * i / sa.signalSamples.Length), (int)(height * (sa.signalSamples [i] + 1f / 2f)), wavColor);
			}

			tex.Apply ();

			yield return new WaitForSeconds (10);
			//draw = true;
		}
	}

	IEnumerator test()
	{
		while (true) {
			yield return new WaitForSeconds(refresh);
			print ("test");
		}
	}
}
