using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bazooka : MonoBehaviour
{

    Vector3 mousePos;
    Vector3 myPos;
    public float min, max;
    playerController pc;

    void Start()
    {
        pc = GetComponentInParent<playerController>();
    }

    void Update()
    {
        mousePos = Input.mousePosition;
        myPos = Camera.main.WorldToScreenPoint(transform.position);

        print(pc.IsFoward);
        if (pc.IsFoward)
            mousePos = mousePos - myPos;
        else
            mousePos = myPos - mousePos;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (pc.IsFoward)
        {
            angle = Mathf.Clamp(angle, min, max);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else
        {
            angle = Mathf.Clamp(angle, -max, -min);
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, -angle));
        }
    }
}