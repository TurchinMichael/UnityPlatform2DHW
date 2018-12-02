using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxTurrelDisable : MonoBehaviour {
    public bool isStay = false;

    public bool IsStay
    {
        get { return isStay; }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "box")
        {
            print(other.gameObject.tag);
            isStay = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "box")
        {
            print(other.gameObject.tag);
            isStay = false;
        }
    }
}
