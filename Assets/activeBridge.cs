using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeBridge : MonoBehaviour
{
    public Rigidbody2D rb;
    public HingeJoint2D hj;
    public List<mySpawn> mySpawns;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject.tag);
        if (other.tag == "Player")
        {
            hj.useMotor= true;
            StartCoroutine("disable");

            foreach(mySpawn obj in mySpawns)
                obj.Spawn();
            //print(other.gameObject.tag);
        }
    }


    IEnumerator disable()
    {
        yield return new WaitForSeconds(2f);
        hj.useMotor = false;
        rb.Sleep();
        print("sdf");
    }
}
