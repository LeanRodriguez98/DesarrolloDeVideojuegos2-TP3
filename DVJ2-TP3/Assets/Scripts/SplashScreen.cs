using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SplashScreen : MonoBehaviour {
    private RawImage Image01 = null;
    private float Alpha;
    private Color NewColor;
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
     
        if (Alpha < 1)
        {
            Alpha += Time.deltaTime / 10;
         
            NewColor.a = Alpha;
            Image01.color = NewColor;

        }
    }
}
