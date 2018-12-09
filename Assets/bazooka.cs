using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bazooka : MonoBehaviour
{

    Vector3 mousePos;
    Vector3 myPos;
    public float min, max;
    playerController pc;

    public GameObject bullet; // Наш снаряд
    public GameObject startBullet; // точка, где он создается

    bool canShoot;
    public float shootTimer = 20;
    float tempTimer;

    void Start()
    {
        pc = GetComponentInParent<playerController>();
    }

    void Update()
    {
        tempTimer -= Time.deltaTime;
        if (tempTimer <= 0)
        {
            canShoot = true;
        }


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

        // стрельба
        if (Input.GetButtonDown("Fire1"))
        {
            fire(bullet, startBullet.transform.position);
        }
    }

    /// <summary>
    /// Метод стреляющий снарядом
    /// </summary>
    /// <param name = "packet" > объект снаряда</param>
    /// <param name = "startForPacket" > позиция создания снаряда</param>
    void fire(GameObject packet, Vector3 startForPacket)
    {
        if (canShoot)
        {
            Instantiate(packet, startForPacket, transform.rotation);
            tempTimer = shootTimer;
            canShoot = false;
        }
    }
}