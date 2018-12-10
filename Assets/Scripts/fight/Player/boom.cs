using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour {

    public float explosionRadius = 20;
    public float power = 500;
    public int damage = 1;
    public float timeBeforeTheExplosion = 5;
    Collider2D[] colliders;
    
    void OnCollisionEnter2D(Collision2D other)
    {
      //  print(other.gameObject.tag);
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            StartCoroutine("Boom");
        }
    }

    IEnumerator Boom()
    {
        yield return new WaitForSeconds(timeBeforeTheExplosion);
        
        colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D hit in colliders)
        {
            if (hit.attachedRigidbody != null && hit.tag != "Player")
            {
                Vector3 direction = hit.transform.position - transform.position;
                direction.z = 0;

                hit.attachedRigidbody.AddForce(direction.normalized * power);

                if (hit.GetComponent<MyEnemy>())
                    hit.GetComponent<MyEnemy>().Hurt(damage);

                if (hit.GetComponent<myPlayerHealth>())
                    hit.GetComponent<myPlayerHealth>().getDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
