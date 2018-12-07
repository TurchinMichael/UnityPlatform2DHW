using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTarget : MonoBehaviour {
    public Transform target;
    Vector3 difference;

    // Use this for initialization
    void Start () {
        difference = transform.position - target.position;

    }
	
	// Update is called once per frame
	void Update () {
        if (target)
            transform.position = target.position + difference;
	}
}
