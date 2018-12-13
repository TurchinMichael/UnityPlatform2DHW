using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootPlayer : MonoBehaviour {
    public GameObject BOOM;
    public int damage;
    public float Speed, LifeTime;
    //Vector3 dir = new Vector3(0, 0, 0);
    Rigidbody2D rb2d;

    void Start()
    {
        Destroy(gameObject, LifeTime);
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb2d.AddForce(new Vector2(transform.right.x, transform.right.y) * Speed, ForceMode2D.Impulse);
        //rb2d.velocity = -transform.forward * Speed;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            //print("popal");
            if(collision.gameObject.GetComponent<myPlayerHealth>())
                collision.gameObject.GetComponent<myPlayerHealth>().getDamage(damage);
            if (collision.gameObject.GetComponent<MyEnemy>())
                collision.gameObject.GetComponent<MyEnemy>().Hurt(damage);

            if (GetComponentInChildren<ParticleSystem>())
                GetComponentInChildren<ParticleSystem>().gameObject.transform.parent = null;

            Destroy(gameObject);
        }
        if (GetComponentInChildren<ParticleSystem>())
        GetComponentInChildren<ParticleSystem>().gameObject.transform.parent = null;

        Instantiate(BOOM, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
