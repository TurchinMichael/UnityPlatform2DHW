using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public struct sprite_text
{
    public KeyCode keyboard;
    public Image HUD_Image;
    public Sprite spriteOriginal;
    public Sprite spriteClicked;
    public Text HUD_text;
    public string text;
}

public class tutorial : MonoBehaviour
{

    GameObject hero;
    public Image square;
    [SerializeField]
    public List<sprite_text> st;

    // Use this for initialization
	void Start () {
        hero = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        checkHUD();
    }

    void checkHUD()
    {
        if (hero && square.enabled)
            square.transform.position = Camera.main.WorldToScreenPoint(hero.transform.position);

        foreach (sprite_text obj in st)
        {
            if (obj.HUD_Image && obj.HUD_Image.enabled)
            {
                if (obj.text != string.Empty && obj.HUD_text)
                    obj.HUD_text.text = obj.text;

                if (obj.keyboard != KeyCode.None && Input.GetKeyDown(obj.keyboard))
                    obj.HUD_Image.sprite = obj.spriteClicked;

                if (obj.keyboard != KeyCode.None && Input.GetKeyUp(obj.keyboard))
                    obj.HUD_Image.sprite = obj.spriteOriginal;
            }
        }
    }
}
