using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            if (collision.GetComponent<myPlayerHealth>())
            {
                collision.GetComponent<myPlayerHealth>().getHeal(1);
                Destroy(gameObject);
            }
    }
}
