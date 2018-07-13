using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BottonsManager : MonoBehaviour {
    public GameObject Button01;
    public GameObject Button02;
    public GameObject Button03;
    public GameObject LandButton;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Ship.instance != null)
        {
            if (Ship.instance.LandPlanetButton)
            {
                LandButton.SetActive(true);
            }
            else
            {
                LandButton.SetActive(false);
            }
        }        
    }

    public void Pause()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            if (Button01 != null)            
                Button01.SetActive(true);
            if (Button02 != null)
                Button02.SetActive(true);
            if (Button03 != null)
                Button03.SetActive(true);

        }
        else
        {
            Time.timeScale = 1;
            if (Button01 != null)
                Button01.SetActive(false);
            if (Button02 != null)
                Button02.SetActive(false);
            if (Button03 != null)
                Button03.SetActive(false);
        }
    }

    public void Test()
    {
        Debug.Log("TEST");
    }

    public void Land()
    {
        switch (Ship.instance.target.type)
        {
            case PlanetType.Type01:
                SceneManager.LoadScene("Planet01");
                break;
            case PlanetType.Type02:
                SceneManager.LoadScene("Planet02");
                break;
            case PlanetType.Type03:
                SceneManager.LoadScene("Planet03");
                break;
            default:
                break;
        }
    }

    public void Change_Scense(string LevelName)
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }

        SceneManager.LoadScene(LevelName);
    }
}
