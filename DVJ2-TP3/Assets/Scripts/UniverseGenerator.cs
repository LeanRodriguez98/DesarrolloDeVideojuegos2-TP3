using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseGenerator : MonoBehaviour {
    public GameObject Sun;
    public GameObject Planet01;
    public GameObject Planet02;
    public GameObject Planet03;
    public int CantPlanets;
    public int PlanetsToGenerate;
    public int PlanetSeparation;
    private int randomPlanet;
  
	// Use this for initialization
	void Start () {
        Instantiate(Sun, new Vector3(0, 0, 0), Quaternion.identity);

        for (int i = 1; i <= PlanetsToGenerate; i++)
        {
            randomPlanet = Random.Range(0, CantPlanets);

            if (randomPlanet == 0)
                Instantiate(Planet01, new Vector3(Random.Range(1, PlanetSeparation) + (i * PlanetSeparation), 0, Random.Range(1, PlanetSeparation) + (i * PlanetSeparation)), Quaternion.identity);
            if (randomPlanet == 1)
                Instantiate(Planet02, new Vector3(Random.Range(1, PlanetSeparation) + (i * PlanetSeparation), 0, Random.Range(1, PlanetSeparation) + (i * PlanetSeparation)), Quaternion.identity);
            if (randomPlanet == 2)
                Instantiate(Planet03, new Vector3(Random.Range(1, PlanetSeparation) + (i * PlanetSeparation), 0, Random.Range(1, PlanetSeparation) + (i * PlanetSeparation)), Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {

        
	}
}
