using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SplashScreen : MonoBehaviour {
    public float Fade = 10;
    public float wait = 2;

    private RawImage Image01 = null;
    private float Alpha;
    private Color NewColor;
    private bool FadeOut = false;
    private float time = 0;

	// Use this for initialization
	void Start () {
        Alpha = 0;
        NewColor.b = 255;
        NewColor.g = 255;
        NewColor.r = 255;
        Image01 = this.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update () {

        if (!FadeOut && Alpha < 1)
        {
            Alpha += Time.deltaTime / Fade;

            NewColor.a = Alpha;
            Image01.color = NewColor;
        }
        else
        {
            time += Time.deltaTime;
            if (time >= wait)
            {
                FadeOut = true;
                Alpha -= Time.deltaTime / Fade;
                NewColor.a = Alpha;
                Image01.color = NewColor;
            }
        }

    }
}
