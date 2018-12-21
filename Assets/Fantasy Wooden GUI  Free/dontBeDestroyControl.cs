using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontBeDestroyControl : Singleton<dontBeDestroyControl> {

    public static dontBeDestroyControl instance = null; // Экземпляр объекта

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        if (instance != this)
            Destroy(gameObject);
    }
}
