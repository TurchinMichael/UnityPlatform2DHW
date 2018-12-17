using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

delegate void Action();

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
    public Text task;
    public Text tipHud;

    public PlayerController playerController;
    public Jump jump;
    public BombPlayer bomb;
    public Bazooka bazooka;
    public myPlayerHealth myHealth;
    public mySpawn spawn;

    public GameObject platform;
    GameObject target;


    bool one, two, three, isPrint, final;
    // Use this for initialization
    void Start()
    {        
        hero = GameObject.FindWithTag("Player");
        myHealth.infOn();
        IsEnableAllCopoments(false);
        StartCoroutine(TextPrint(task, "Привет, это твой герой, его только создали и вручили базуку с бомбами, он не помнит как двигаться. \nНапомни ему.", "A D клавиши передвижения, научить ходить персонажа", 0.04f, oneVoid/*, skipText*/));
    }

    void Update()
    {
        checkHUD();

        if (one)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
            {
                isPrint = false;
                one = false;
                StartCoroutine(TextPrint(task, "Отлично! Теперь заставь его запрыгнуть вот на эту платформу.", "Space клавиша прыжка, запрыгнуть на платформу.",  0.04f, twoVoid/*, skipText*/));
            }
        }
    }

    public void PlatformOk(Collider2D collision)
    {
        if (two && collision.tag == "Player")
        {
            //print(collision.name);
            isPrint = false;
            two = false;
            StartCoroutine(TextPrint(task, "Супер! Ты исполнительный. Пройди правее, и ты встретишь преграду. Тебе надо пройти через неё. \nВзорви её! \nБомбы взрываются через некоторое время.", "Z клавиша броска бомбы, взорвать стену", 0.04f, threeVoid/*, skipText*/));
            square.enabled = false;
        }
    }

    public void BoomOk(Collider2D collision)
    {
        if (three && collision.tag == "Player")
        {
            //print(collision.name);
            isPrint = false;
            three = false;
            StartCoroutine(TextPrint(task, "Ну чтож, молодец. Теперь посмотрим, на что ты способен.", "Левая кнопка мыши выстрел, убить врага", 0.04f, fourVoid/*, skipText*/));
            //spawn.enemy.AddComponent<loadNewScene>();
            //loadNewScene z = spawn.enemy.GetComponent<loadNewScene>();
            //Destroy(z, 0.1f);
            //GameObject.FindWithTag("Enemy").GetComponent<loadNewScene>().GetTextField(task);
            final = true;
        }
    }

    public void finalOk()
    {
        if (final)
        {
            //print(collision.name);
            isPrint = false;
            //two = false;
            StartCoroutine(TextPrint(task, "Отлично сработано, возможно ты мне пригодишься, посмотрим, справишься ли ты с моей задачей.", "Решить задачу", 0.04f, finalVoid/*, skipText*/));
            //square.enabled = false;
            //print("2");
        }
    }


    void oneVoid()
    {
        target = hero;
        square.enabled = true;
        TutorialHudElementsShowHide(new int[2] { 0, 1 }, true);
        playerController.enabled = true;
        one = true;
    }

    void twoVoid()
    {
        //TutorialHudElementsShowHide(new int[2] { 0, 1 }, true);
        TutorialHudElementsShowHide(new int[1] { 4 }, true);
        target = platform;
        platform.SetActive(true);
        jump.enabled = true;
        two = true;
    }

    void threeVoid()
    {
        //TutorialHudElementsShowHide(new int[2] { 0, 1 }, true);
        TutorialHudElementsShowHide(new int[1] { 2 }, true);
        three = true;
        bomb.enabled = true;
    }

    void fourVoid()
    {
        //TutorialHudElementsShowHide(new int[2] { 0, 1 }, true);
        TutorialHudElementsShowHide(new int[1] { 3 }, true);
        //three = true;
        bazooka.enabled = true;
        myHealth.infOff();
        myHealth.showHud();
        task.text = string.Empty;

        spawn.Spawn();
        GameObject.FindWithTag("Enemy").AddComponent<loadNewScene>();
    }

    void finalVoid()
    {
        SceneManager.LoadScene("Level1");
        SceneManager.UnloadSceneAsync("tutorial");
    }

    void TutorialHudElementsShowHide(int[] indexes, bool showHide)
    {
        for (int i = 0; i < indexes.Length; i++)
        {
            if (st[indexes[i]].HUD_text)
                st[indexes[i]].HUD_text.enabled = showHide;

            if (st[indexes[i]].HUD_Image)
                st[indexes[i]].HUD_Image.enabled = showHide;
        }
    }

    void IsEnableAllCopoments(bool trueFalse)
    {
        myHealth.hideHud();
        myHealth.enabled = trueFalse;
        playerController.enabled = trueFalse;
        jump.enabled = trueFalse;
        bomb.enabled = trueFalse;
        bazooka.enabled = trueFalse;
        square.enabled = trueFalse;
        platform.SetActive(trueFalse);

        foreach (sprite_text obj in st)
        {
            if (obj.HUD_Image && obj.HUD_Image.enabled)
            {
                if (obj.HUD_text)
                    obj.HUD_text.enabled = trueFalse;

                if (obj.HUD_Image)
                    obj.HUD_Image.enabled = trueFalse;
            }
        }
    }

    void SquareFollow()
    {
        if (target)
            square.transform.position = Camera.main.WorldToScreenPoint(target.transform.position);
    }

    void checkHUD()
    {
        if (square.enabled)
            SquareFollow();

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

    IEnumerator TextPrint(Text output, string input, string tip, float delay, Action action/*, ref bool skip*/)
    {
        if (isPrint) yield break;
        isPrint = true;

        //вывод текста побуквенно
        for (int i = 0; i <= input.Length; i++)
        {
            //if (skip) { output.text = input; yeld break; }
            //print(input[0]);
            output.text = input.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(1);
        action.Invoke();
        tipHud.text = tip;
    }
}
