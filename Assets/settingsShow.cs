using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingsShow : MonoBehaviour {

    bool isActive;
    public Canvas settingsHUD, tutorialHUD;
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            HUDChangeEnabled();
    }

    public void HUDChangeEnabled()
    {
        if(settingsHUD)
        settingsHUD.enabled = !settingsHUD.enabled;
        if (tutorialHUD)
            tutorialHUD.enabled = !tutorialHUD.enabled;
        isActive = !isActive;
    }
}
