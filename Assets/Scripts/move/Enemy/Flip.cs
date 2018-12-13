using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public GameObject target;
    Vector3 targetPos, myPos;
    Vision vision;
    Vector3 startPosition;

    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player");
        vision = GetComponent<Vision>();
        startPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (target && vision.isSee())
        {
            Flipping(target.transform.position);
        }
        else
        {
            Flipping(startPosition);
        }
    }

    void Flipping(Vector3 targetPosition)
    {
        targetPos = Camera.main.WorldToScreenPoint(targetPosition);

        myPos = Camera.main.WorldToScreenPoint(transform.position);

        targetPos = targetPos - myPos;

        //print(targetPos);
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;

        //print(Mathf.Abs(angle));
        if (Mathf.Abs(angle) > 90)
            angle = 180;
        else
            angle = 0;

        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }
}