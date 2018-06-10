using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public RawImage icon01;
    public RawImage icon02;

    private float appearIn;
    private float time = 0;
    private SplashScreen splash01;

    private void Start()
    {
        splash01 = icon01.GetComponent<SplashScreen>();
        appearIn = splash01.wait * 3;
    }

    // Update is called once per frame
    void Update () {
        time += Time.deltaTime;
        if (time >= appearIn)
        {
            icon02.gameObject.SetActive(true);
        }
	}
}
