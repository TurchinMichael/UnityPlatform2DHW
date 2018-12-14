using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontBeDestroy : Singleton<dontBeDestroy> {

    public static dontBeDestroy instance = null; // Экземпляр объекта

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
