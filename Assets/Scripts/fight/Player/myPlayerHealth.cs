using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myPlayerHealth : MonoBehaviour {
    int currentHealth;
    public int startHealth;
    public Text text;
    public Slider slider;
    
    public reloadScene reloaderScene;

    private void Start()
    {
        currentHealth = startHealth;
        slider.maxValue = startHealth;
        slider.interactable = false;
        slider.value = startHealth;
        text.text = slider.value.ToString();
    }

    public void getDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        slider.value = Mathf.Clamp(currentHealth, 0, startHealth);
        text.text = slider.value.ToString();

        if (slider.value == 0)
        {
            slider.fillRect.gameObject.SetActive(false);
            text.text = "last chance";
        }
        if (currentHealth < 0)
        {
            dead();
        }
    }

    void dead()
    {
        print("health " + currentHealth);
        // .. stop the camera tracking the player
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;

        Destroy(text);
        Destroy(slider.gameObject);
        Destroy(gameObject);

        // ... reload the level.
        reloaderScene.reload();
    }

    public void infOn()
    {
        currentHealth = int.MaxValue;
    }

    public void infOff()
    {
        currentHealth = startHealth;
        slider.value = startHealth;
        text.text = slider.value.ToString();
    }

    public void hideHud()
    {
        slider.gameObject.SetActive(false);
    }

    public void showHud()
    {
        slider.gameObject.SetActive(true);
    }
}
