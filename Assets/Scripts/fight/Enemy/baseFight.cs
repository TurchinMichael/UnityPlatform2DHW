using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class baseFight : MonoBehaviour
{
    protected GameObject HitSprite;
    protected float ShootTimer;
    protected float DistanceAttack;
    protected bool canHit = true;
    protected Transform Target;
    protected Transform StartForHit;
    protected float tempTimer;
    protected int Damage;

    public void Init(float shootSpeed, float distanceAttack,
     GameObject hitPrefab,
     int damage,
     Transform target,
     Transform startForHit)
    {
        ShootTimer = shootSpeed;
        tempTimer = ShootTimer;
        DistanceAttack = distanceAttack;
        HitSprite = hitPrefab;
        Damage = damage;
        Target = target;
        StartForHit = startForHit;
    }

public virtual void Attack()
    {
        if (Target)
        {
            tempTimer -= Time.deltaTime;
            if (tempTimer <= 0)
                canHit = true;

            if (Vector2.Distance(transform.position, Target.position) < DistanceAttack)
            {
                if (canHit)
                {
                    Target.GetComponent<myPlayerHealth>().getDamage(Damage);

                    canHit = false;
                    tempTimer = ShootTimer;
                    Instantiate(HitSprite, StartForHit.position, transform.rotation);
                }
            }
        }
    }
}