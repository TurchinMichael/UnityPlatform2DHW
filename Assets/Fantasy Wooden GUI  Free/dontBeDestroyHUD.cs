using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontBeDestroyHUD : Singleton<dontBeDestroyHUD> {

    public static dontBeDestroyHUD instance = null; // Экземпляр объекта

    private void Awake()
    {
        if (instance == null)
        { // Экземпляр менеджера был найден
            instance = this; // Задаем ссылку на экземпляр объекта
        }
        else if (instance != null)
        { // Экземпляр объекта уже существует на сцене
            Destroy(this.gameObject); // Удаляем объект
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
