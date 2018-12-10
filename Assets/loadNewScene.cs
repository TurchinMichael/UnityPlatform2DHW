using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadNewScene : MonoBehaviour {
    
    public void loadScene()
    {
       // print("2");
        GameObject.FindWithTag("TutorialHUD").GetComponent<tutorial>().finalOk();
    }

    private void OnDestroy()
    {
        //print("1");
        loadScene();
    }
}