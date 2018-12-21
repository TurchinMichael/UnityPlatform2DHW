using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour {

    //AudioListener mainListener;

    //private void Start()
    //{
    //    //if (Camera.main.GetComponent<AudioListener>())
    //    //    mainListener = Camera.main.GetComponent<AudioListener>();
    //    //if (mainListener)
    //}

    private void Update()
    {
    }


    public void StartGame()
    {
        NewMethod();
        SceneManager.LoadSceneAsync(1);
    }

    private static void NewMethod()
    {
        SceneManager.UnloadSceneAsync(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
