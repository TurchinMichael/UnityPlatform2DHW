using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour {

    public float explosionRadius = 20;
    public float power = 500;
    public int damage = 1;
    public float timeBeforeTheExplosion = 5;
    Collider2D[] colliders;
    ParticleSystem[] particles;
    AudioSource audioSource;

    private void Awake()
    {
        if (GetComponentInChildren<ParticleSystem>())
            particles = GetComponentsInChildren<ParticleSystem>();

        if (particles.Length > 0)
            foreach (ParticleSystem obj in particles)
            {
                var mn = obj.main;
                mn.playOnAwake = false;
                obj.transform.localScale = new Vector3(1, 1, 1);
                var sh = obj.shape;
                sh.radius = explosionRadius;
                obj.Stop();
            }

        if (GetComponentInChildren<AudioSource>())
        {
            audioSource = GetComponentInChildren<AudioSource>();
            audioSource.Stop();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine("Boom");
    }

    IEnumerator Boom()
    {
        yield return new WaitForSeconds(timeBeforeTheExplosion);
        
        colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        if (particles.Length > 0)
            foreach (ParticleSystem obj in particles)
            {
                print(obj.name);
                obj.Play();
            }
        audioSource.transform.parent = null;
        audioSource.gameObject.AddComponent<selfDestroy>().timeDestroy = 2f;
        audioSource.Play();

        yield return new WaitForSeconds(particles[0].duration);

        foreach (Collider2D hit in colliders)
        {
            if (hit.attachedRigidbody != null && hit.tag != "Player")
            {
                Vector3 direction = hit.transform.position - transform.position;
                direction.z = 0;

                hit.attachedRigidbody.AddForce(direction.normalized * power);

                if (hit.tag == "Wall")
                {
                    hit.attachedRigidbody.AddForce(direction.normalized * power * 10);
                    hit.attachedRigidbody.mass = 1;
                }
                
                if (hit.GetComponent<MyEnemy>())
                    hit.GetComponent<MyEnemy>().Hurt(damage);

                //if (hit.GetComponent<myPlayerHealth>())
                //    hit.GetComponent<myPlayerHealth>().getDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
