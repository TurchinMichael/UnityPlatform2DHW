using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public float aggroDistance;
    public string[] layers = new string[] { "Player", "Ground" };
    public RaycastHit2D hit;
    Transform target;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    public bool isSee()
    {
        hit = Physics2D.Raycast(transform.position, target.position - transform.position, aggroDistance, LayerMask.GetMask(layers));

        return (Vector3.Distance(transform.position, target.position) < aggroDistance &&
        hit.collider != null &&
        hit.collider.gameObject.tag == "Player");
    }
}
