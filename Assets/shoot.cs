using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject BOOM;
    public int Damage;
    public float Speed, LifeTime;
    Vector3 Dir = new Vector3(0, 0, 0);
    AudioSource m_MyAudioSource;

    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();

        if (GameObject.FindGameObjectWithTag("Player").transform.localScale.x > 0)
        Dir.x = Speed;

        if (GameObject.FindGameObjectWithTag("Player").transform.localScale.x < 0)
        {
            Dir.x = -Speed;
            Vector3 theScale;
            theScale = transform.localScale;
            theScale.x *= -1;
            Debug.Log("ASDasd");
            this.transform.localScale = theScale;
        }

        Destroy(gameObject, LifeTime);
    }
    void FixedUpdate()
    {
        //if (GameObject.FindGameObjectWithTag("Player").transform.localScale.x < 0)
        //{
        //    Debug.Log("-= Dir");
        //    transform.position -= Dir;
        //}
        //if (GameObject.FindGameObjectWithTag("Player").transform.localScale.x > 0)
        //{
        //    Debug.Log("+= Dir");
            transform.position += Dir;
        //}

            //transform.position += Dir;
        // Движение снаряда
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ENEMY");
        // Если объект с которым мы столкнулись имеет тег Enemy
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("ENEMY");
            MyEnemy Enemy = collision.gameObject.GetComponent<MyEnemy>();
            // Делаем ссылку на объект противника
            if (Enemy != null) // Если ссылка не пуста
            {
                Enemy.Hurt(Damage); // Вызываем метод урона и указываем его размер
                // Спауним объект, который симулирует взрыв
                Instantiate(BOOM, transform.position, transform.rotation);


                m_MyAudioSource.Play();
                // Уничтожаем пулю
                Destroy(gameObject);
            }
        }
    }
}
