using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollider : MonoBehaviour {
    public GameObject[] targets;
    public bool isTarget;
	// Use this for initialization
	void Start () {
        this.isTarget = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (other.tag == targets[i].tag)
            {
                this.isTarget = true;
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (other.tag == targets[i].tag)
            {
                this.isTarget = false;
            }
        }
    }
}
