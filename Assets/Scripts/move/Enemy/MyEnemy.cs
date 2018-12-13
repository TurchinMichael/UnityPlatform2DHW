using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyEnemy : MonoBehaviour
{
    private int heath = 2;
    public int damage = 1;
    Transform target;
    Rigidbody2D rb2d;
    public float moveSpeed = 2f;
    public float maxSpeed = 100f;
    Vision vision;
    Animator animator;
    Flip flip;
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
            Destroy(transform.parent.gameObject);
            //Destroy(gameObject);
        }
    }
    Scene m_Scene;

    void Awake()
    {
        startPosition = transform.position;
        target = GameObject.FindWithTag("Player").transform;
        vision = GetComponent<Vision>();
        if (GetComponent<Animator>())
            animator = GetComponent<Animator>();
        if (GetComponent<Rigidbody2D>())
            rb2d = GetComponent<Rigidbody2D>();
        //if (GetComponent<Flip>())
        //    flip = GetComponent<Flip>();
    }

    public float aggroDistance;
    string[] layers = new string[] { "Player", "Ground" };
    RaycastHit2D hit;

    void FixedUpdate()
    {
        if (target != null)
        {
            hit = Physics2D.Raycast(transform.position, target.position - transform.position, aggroDistance, LayerMask.GetMask(layers));

            Debug.DrawRay(transform.position, (target.position.normalized - transform.position.normalized) * 5);

            if (vision.isSee())
            {
                rb2d.AddForce(new Vector2(Mathf.Clamp((target.position.x - transform.position.x) * moveSpeed /** Time.deltaTime*/, -maxSpeed, maxSpeed), GetComponent<Rigidbody2D>().velocity.y));
                //rb2d.velocity = new Vector2((target.position.x - transform.position.x) * moveSpeed, rb2d.velocity.y);
            }
            else
            {
                rb2d.AddForce(new Vector2(Mathf.Clamp((startPosition.x - transform.position.x) * moveSpeed /** Time.deltaTime*/, -maxSpeed, maxSpeed), GetComponent<Rigidbody2D>().velocity.y));
                //rb2d.velocity = new Vector2((startPosition.x - transform.position.x) * moveSpeed, rb2d.velocity.y);
            }
        }

        if (rb2d && animator)
            animator.SetFloat("speed", rb2d.velocity.x);

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

    //public void Flip()
    //{
    //    Vector3 enemyScale = transform.localScale;
    //    enemyScale.x *= -1;
    //    transform.localScale = enemyScale;
    //}

}