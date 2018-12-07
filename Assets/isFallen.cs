using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isFallen : MonoBehaviour {
    //bool isFall = true;
    HingeJoint2D hinge;

    private void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
    }

    //public bool IsFall
    //{
    //    get { return isFall; }
    //    set { isFall = value; }
    //}

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.transform.tag == "Player")
        {
            //isFall = true;
            hinge.useMotor = false;
        }
    }
}
