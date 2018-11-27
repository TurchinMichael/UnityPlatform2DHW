using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour {
    private int heath = 20;
    public void Hurt(int Damage)
    {
        heath -= Damage;
        Debug.Log("Ouch: " + heath);
        if (heath <= 0)
        {
            Debug.Log("dead: ");
            Destroy(gameObject);
        }
    }
}
