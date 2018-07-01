using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollider : MonoBehaviour {
    public GameObject target;
    [HideInInspector]public bool isTarget;
	// Use this for initialization
	void Start () {
        this.isTarget = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == target.tag)
        {
            this.isTarget = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == target.tag)
        {
            this.isTarget = false;
        }
    }
}
