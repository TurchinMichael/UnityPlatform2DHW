using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour {
    public task taskFinish;
    bool first;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!first)
        {
            if (collision.tag == "Player")
            {
                //print("finish");
                taskFinish.textPrintFowardBack("Ты выполнил первую задачу, молодец.", "Жди новой задачи.", 0.04f);
                first = true;
            }
        }
    }
}
