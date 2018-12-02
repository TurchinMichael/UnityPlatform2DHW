using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {
    bool enable;
    public Transform target;
    public Transform idleTarget;
    public float speed, distanceAttack;

    public float shootTimer = 20;
    float tempTimer;
    bool canShoot;

    public List<boxTurrelDisable> boxesDisable;
    Vector3 vectorToTarget;
    Quaternion q;
    RaycastHit2D hit;
    string[] layers = new string[] { "Player", "Ground" };
    
    
    // Update is called once per frame
    void Update () {
        for (int i  = 0; i < boxesDisable.Count; i++)
        {
            if (!boxesDisable[i].IsStay)
            {
                enable = true;
                break;
            }
                enable = false;
        }

        if (enable)
        {

            if (target != null)
                hit = Physics2D.Raycast(transform.position, target.position - transform.position, distanceAttack, LayerMask.GetMask(layers));
            
            tempTimer -= Time.deltaTime;
            if (tempTimer <= 0)
            {
                canShoot = true;
            }

            if (target != null && hit.collider != null && hit.collider.gameObject.tag == "Player")
            {
                lerpTarget(target);
                if (canShoot)
                    fire();
            }
            else
            {
                lerpTarget(idleTarget);
            }
        }
    }

    /// <summary>
    /// плавное изменение направления стрельбы
    /// </summary>
    /// <param name="targetLerp"></param>
    void lerpTarget(Transform targetLerp)
    {
        if (Vector3.Distance(transform.position, targetLerp.position) < distanceAttack)
        {
            vectorToTarget = targetLerp.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, q, Time.deltaTime * speed);
        }
    }

    public GameObject packetTurret;
    public Transform startForPacketTurret;

    /// стрельба из туррели
    /// </summary>
    /// <param name = "packet" > объект снаряда</param>
    /// <param name = "startForPacket" > позиция создания снаряда</param>
    void fire()
    {
        canShoot = false;
        tempTimer = shootTimer;
        Instantiate(packetTurret, startForPacketTurret.position, transform.rotation);
    }
}