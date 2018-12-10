using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attackController : MonoBehaviour {
    meleeAttack melee;
    rangeAttack range;
    public Image meleeIndicator, rangeIndicator;


    // Use this for initialization
    void Start () {
        melee = GetComponent<meleeAttack>();
        range = GetComponent<rangeAttack>();

        rangeIndicator.enabled = range.enabled;
        meleeIndicator.enabled = melee.enabled;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R))
        {
            range.enabled = !range.enabled;
            rangeIndicator.enabled = range.enabled;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            melee.enabled = !melee.enabled;
            meleeIndicator.enabled = melee.enabled;
        }
    }
}
