using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class myPlayerHealth : MonoBehaviour {
    public int health;
    public reloadScene reloaderScene;

    public void getDamage(int damage)
    {
        health = health - damage;
        if (health < 0)
            dead();
    }

    void dead()
    {
        print("health " + health);
        // .. stop the camera tracking the player
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;

        // ... reload the level.
        reloaderScene.reload();

        Destroy(gameObject);
    }
}
