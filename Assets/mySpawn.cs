using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mySpawn : MonoBehaviour {

    public float spawnTime = 5f;        // The amount of time between each spawn.
    public float spawnDelay = 3f;       // The amount of time before spawning starts.
    public GameObject enemy;        // Array of enemy prefabs.


    //void Start()
    //{
    //    // Start calling the Spawn function repeatedly after a delay .
    //    InvokeRepeating("Spawn", spawnDelay, spawnTime);
    //}


    public void Spawn()
    {
        // Instantiate a random enemy.
        //int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemy, transform.position, transform.rotation);

        //// Play the spawning effect from all of the particle systems.
        //foreach (ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
        //{
        //    p.Play();
        //}
    }
}
