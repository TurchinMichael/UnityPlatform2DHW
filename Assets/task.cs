using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class task : MonoBehaviour {

    bool isPrint;
    public Text taskText;
    public Text tipHud;
    public myCamera _myCamera;
    // Use this for initialization

    void Start () {
        textPrintFoward("Твоей первой задачей будет придвинуть два маленьких ящика к двум ящикам большим.\nЕсли ты конечно не хочешь пару ракет от замечательной турели, которая находится в левой части этого прекрасного места. \nРазберешься...",
            "Отключить туррель придвинув два маленьких ящика к двум ящикам большим.", 0.04f);
    }

    public void textPrintFoward(string text, string tip, float delay)
    {
        //StopAllCoroutines();
        isPrint = false;
        StartCoroutine(TextPrint(taskText, text, tip, delay, 1/*, skipText*/));
    }

    public void textPrintBack(string text, string tip, float delay)
    {
        //StopAllCoroutines();
        isPrint = false;
        StartCoroutine(TextPrint(taskText, text, tip, delay, 2/*, skipText*/));
    }

    public void textPrintFowardBack(string text, string tip, float delay)
    {
        //StopAllCoroutines();
        isPrint = false;
        StartCoroutine(TextPrint(taskText, text, tip, delay, 3/*, skipText*/));
    }

    /// <summary>
    /// Перебор для корутины, отображающий текст побуквенно
    /// </summary>
    /// <param name="output"> В какой UI текст это будет выводиться </param>
    /// <param name="input"> Текст, который будет выводиться </param>
    /// <param name="delay"> Задержка перед написанием буквы </param>
    /// <param name="howWrite">Как рисовать текст: 1 - побуквенно нарисовать; 2 - полностью нарисовать и удалять побуквенно с конца; 3 - побуквенно нарисовать и удалять побуквенно с конца. </param>
    /// <returns></returns>
    IEnumerator TextPrint(Text output, string input, string tip, float delay, int howWrite/*, ref bool skip*/)
    {
        if (isPrint) yield break;
        isPrint = true;

        int h = input.Length / _myCamera.targetsCount, k = 0;

        if (howWrite == 1 || howWrite == 3)
        {
            //вывод текста побуквенно
            for (int i = 0; i <= input.Length; i++)
            {
                //if (skip) { output.text = input; yeld break; }
                //print(input[0]);
                output.text = input.Substring(0, i);
                //_myCamera.target = 3;
                //print(_myCamera.target);

                if (i == h)
                {
                    _myCamera.target = k;
                    //print(k);
                    h = h + input.Length / _myCamera.targetsCount;
                    k++;
                }

                yield return new WaitForSeconds(delay);
            }
        }

        yield return new WaitForSeconds(1.5f);
        //_myCamera.target = 0;

        if (howWrite == 1)
        {
            output.text = string.Empty;
            tipHud.text = tip;
        }

        if (howWrite == 2 || howWrite == 3)
            StartCoroutine(BackTextPrint(output, input, tip, delay/*, skipText*/));
    }

    IEnumerator BackTextPrint(Text output, string input, string tip, float delay/*, ref bool skip*/)
    {
        //if (isPrint) yield break;
        //isPrint = true;

        for (int i = input.Length; i >= 0; i--)
        {
            //if (skip) { output.text = input; yeld break; }
            //print(input[0]);
            output.text = input.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(1);
        tipHud.text = tip;
    }
}
