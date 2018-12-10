using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeAttack : baseFight
{
    public float shootSpeed, distanceAttack, blindZoneAttack;
    public GameObject hitPrefab;
    public int damage;
    public Transform startForHit;
    Vision vision;

    void Start()
    {
        Init(shootSpeed, distanceAttack, hitPrefab, damage, GameObject.FindWithTag("Player").transform, startForHit);
        vision = GetComponentInParent<Vision>();
    }

    void Update()
    {
        Attack();
    }

    public override void Attack()
    {
        if (Target)
        {
            tempTimer -= Time.deltaTime;

            if (tempTimer <= 0)
                canHit = true;

            Vector3 vectorToTarget = Target.position - transform.position;

            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            if (Vector2.Distance(transform.position, Target.position) < DistanceAttack && Vector2.Distance(transform.position, Target.position) > blindZoneAttack && vision.isSee())
            {
                if (canHit)
                {
                    canHit = false;
                    tempTimer = ShootTimer;
                    Instantiate(HitSprite, StartForHit.position, Quaternion.AngleAxis(Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg, Vector3.forward));
                }
            }
        }
    }
}