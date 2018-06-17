using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonsManager : MonoBehaviour {
    public Ship _Ship;
    public GameObject Button01;
    public GameObject Button02;
    public GameObject Button03;
    public GameObject LandButton;

    // Use this for initialization
    void Start () {
        _Ship = Ship.instance;
	}
	
	// Update is called once per frame
	void Update () {
        if (_Ship.LandPlanetButton)
        {
            LandButton.SetActive(true);
        }
        else
        {
            LandButton.SetActive(false);
        }
    }

    public void Pause()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            Button01.SetActive(true);
            Button02.SetActive(true);
            Button03.SetActive(true);

        }
        else
        {
            Time.timeScale = 1;
            Button01.SetActive(false);
            Button02.SetActive(false);
            Button03.SetActive(false);
        }
    }

    public void Test()
    {
        Debug.Log("TEST");
    }

}
