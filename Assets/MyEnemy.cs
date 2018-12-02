using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour {
    private int heath = 4;
    public int damage = 1;
    public Transform target;

    public float moveSpeed = 2f;        // The speed the enemy moves at. 
    public float maxSpeed = 100f;


    public float shootTimer = 20;
    float tempTimer;
    bool canShoot;

    public float deathSpinMin = -100f;          // A value to give the minimum amount of Torque when dying
    public float deathSpinMax = 100f;           // A value to give the maximum amount of Torque when dying

    private SpriteRenderer ren;         // Reference to the sprite renderer.
    //private Transform frontCheck;       // Reference to the position of the gameobject used for checking if something is in front.
    private bool dead = false;          // Whether or not the enemy is dead.


    public void Hurt(int Damage)
    {
        heath -= Damage;
        Debug.Log("Ouch: " + heath);
        if (heath <= 0)
        {
            Debug.Log("dead: ");
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;

        //    // Setting up the references.
        //    //ren = transform.Find("body").GetComponent<SpriteRenderer>();
        //    //frontCheck = transform.Find("frontCheck").transform;
        //    //Death();
        }

        void FixedUpdate()
    {
        tempTimer -= Time.deltaTime;
        if (tempTimer <= 0)
        {
            canShoot = true;
        }

        if (target != null)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Clamp((target.position.x - transform.position.x) * moveSpeed * Time.deltaTime, -maxSpeed, maxSpeed), GetComponent<Rigidbody2D>().velocity.y));

            if (Vector2.Distance(transform.position, target.position) < 2)
            {
                print("HIT");
                if (canShoot)
                {
                    fire();
                    target.GetComponent<myPlayerHealth>().getDamage(damage);
                }
            }
        }

        if (heath <= 0 && !dead)
            // ... call the death function.
            Death();
    }
    
    void Death()
    {
        // Find all of the sprite renderers on this object and it's children.
        SpriteRenderer[] otherRenderers = GetComponentsInChildren<SpriteRenderer>();

        // Disable all of them sprite renderers.
        foreach (SpriteRenderer s in otherRenderers)
        {
            s.enabled = false;
        }

        // Re-enable the main sprite renderer and set it's sprite to the deadEnemy sprite.
        //ren.enabled = true;

        // Set dead to true.
        dead = true;

        // Allow the enemy to rotate and spin it by adding a torque.
        GetComponent<Rigidbody2D>().AddTorque(Random.Range(deathSpinMin, deathSpinMax));

        // Find all of the colliders on the gameobject and set them all to be triggers.
        Collider2D[] cols = GetComponents<Collider2D>();
        foreach (Collider2D c in cols)
        {
            c.isTrigger = true;
        }

        // Create a vector that is just above the enemy.
        Vector3 scorePos;
        scorePos = transform.position;
        scorePos.y += 1.5f;
    }
    
    public void Flip()
    {
        // Multiply the x component of localScale by -1.
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }


    public GameObject hit;
    public Transform startForHit;

    /// стрельба из туррели
    /// </summary>
    /// <param name = "packet" > объект снаряда</param>
    /// <param name = "startForPacket" > позиция создания снаряда</param>
    void fire()
    {
        canShoot = false;
        tempTimer = shootTimer;
        Instantiate(hit, startForHit.position, transform.rotation);
    }
}