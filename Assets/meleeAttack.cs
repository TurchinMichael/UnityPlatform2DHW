using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAttack : baseFight {
    public float shootSpeed, distanceAttack;
    public GameObject hitPrefab;
    public int damage;
    public Transform startForHit;
    
    void Start () {
        Init(shootSpeed, distanceAttack, hitPrefab, damage, GameObject.FindWithTag("Player").transform, startForHit);
    }
	
	void Update () {
        Attack();
    }
}
