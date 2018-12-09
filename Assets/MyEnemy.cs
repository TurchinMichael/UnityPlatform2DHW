using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    private int heath = 2;
    public int damage = 1;
    Transform target;

    public float moveSpeed = 2f;
    public float maxSpeed = 100f;
    Vision vision;

    //public GameObject hitSprite;
    //public Transform startForHit;


    //public float deathSpinMin = -100f; 
    //public float deathSpinMax = 100f;  

    private SpriteRenderer ren;         // Reference to the sprite renderer.
    //private Transform frontCheck;       // Reference to the position of the gameobject used for checking if something is in front.
    private bool dead = false;          // Whether or not the enemy is dead.

    Vector3 startPosition;
    public void Hurt(int Damage)
    {
        heath -= Damage;
        //Debug.Log("Ouch: " + heath);
        if (heath < 1)
        {
           // Debug.Log("dead: ");
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        startPosition = transform.position;
        target = GameObject.FindWithTag("Player").transform;
        vision = GetComponent<Vision>();
    }

    public float aggroDistance;
    string[] layers = new string[] { "Player", "Ground" };
    RaycastHit2D hit;

    void FixedUpdate()
    {
        if (target != null)
        {
            hit = Physics2D.Raycast(transform.position, target.position - transform.position, aggroDistance, LayerMask.GetMask(layers));

            if (vision.isSee())
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Clamp((target.position.x - transform.position.x) * moveSpeed * Time.deltaTime, -maxSpeed, maxSpeed), GetComponent<Rigidbody2D>().velocity.y));
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Clamp((startPosition.x - transform.position.x) * moveSpeed * Time.deltaTime, -maxSpeed, maxSpeed), GetComponent<Rigidbody2D>().velocity.y));
            }
        }

        if (heath <= 0 && !dead)
            Death();
    }

    void Death()
    {
        SpriteRenderer[] otherRenderers = GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer s in otherRenderers)
        {
            s.enabled = false;
        }

        dead = true;

        //GetComponent<Rigidbody2D>().AddTorque(Random.Range(deathSpinMin, deathSpinMax));

        Collider2D[] cols = GetComponents<Collider2D>();
        foreach (Collider2D c in cols)
        {
            c.isTrigger = true;
        }

        Vector3 scorePos;
        scorePos = transform.position;
        scorePos.y += 1.5f;
    }

    public void Flip()
    {
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }
    
}