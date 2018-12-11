using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class task : MonoBehaviour {

    bool isPrint;
    public Text taskText;
    // Use this for initialization
    void Start () {

        StartCoroutine(TextPrint(taskText, "Твоей первой задачей будет придвинуть два маленьких ящика к двум ящикам большим.\nЕсли ты конечно не хочешь пару ракет от замечательной турели, которая находится в левой части этого прекрасного места. \nРазберешься...", 0.04f/*, skipText*/));
    }

    IEnumerator TextPrint(Text output, string input, float delay/*, ref bool skip*/)
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
        yield return new WaitForSeconds(1.5f);

        StartCoroutine(BackTextPrint(taskText, input, delay/*, skipText*/));
    }

    IEnumerator BackTextPrint(Text output, string input, float delay/*, ref bool skip*/)
    {
        //if (isPrint) yield break;
        //isPrint = true;

        //вывод текста побуквенно
        for (int i = input.Length; i >= 0; i--)
        {
            //if (skip) { output.text = input; yeld break; }
            //print(input[0]);
            output.text = input.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(1);
    }
}
