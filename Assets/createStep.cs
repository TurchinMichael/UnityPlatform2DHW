using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createStep : MonoBehaviour
{
    Jump jump;
    ParticleSystem particleSystem;

    // Use this for initialization
    void Start () {
        if (GetComponentInParent<Jump>())
            jump = GetComponentInParent<Jump>();

       // print(jump);

        if (GetComponent<ParticleSystem>())
            particleSystem = GetComponent<ParticleSystem>();
    }

	// Update is called once per frame
	void Update () {
        //if (jump.IsGrounded())
        //    print("grounded");
        if (jump && particleSystem && jump.IsGrounded())
            particleSystem.Play();
        else
            particleSystem.Stop();
    }
}
