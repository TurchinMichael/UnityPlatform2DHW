using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlayer : MonoBehaviour {

    bool canShoot = true;
    public float shootTimer = 20;
    float tempTimer;

    public GameObject bombPacket; // бомба
    public GameObject startBomb; // точка, где она создается

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        tempTimer -= Time.deltaTime;
        if (tempTimer <= 0)
            canShoot = true;

        // заложить взрывчатку
        if (Input.GetKeyDown(KeyCode.Z))
            fire(bombPacket, startBomb.transform.position);
    }

    /// <summary>
    /// Метод стреляющий снарядом
    /// </summary>
    /// <param name = "packet" > объект снаряда</param>
    /// <param name = "startForPacket" > позиция создания снаряда</param>
    void fire(GameObject packet, Vector3 startForPacket)
    {
        //print("no");
        if (canShoot)
        {
          //  print("yes");
            Instantiate(packet, startForPacket, transform.rotation);
            tempTimer = shootTimer;
            canShoot = false;
        }
    }
}
