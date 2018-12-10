using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public tutorial _tutorial;
    bool first;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.name);
        if (collision.tag == "Player")
        {
            if (this.name == "platfTrigger")
                _tutorial.PlatformOk(collision);

            if (this.name == "triggerBombComplete")
                _tutorial.BoomOk(collision);
        }
    }
}
