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
    Rigidbody2D rb2d;

    void Start()
    {
        //m_MyAudioSource = GetComponent<AudioSource>();

        //if (GameObject.FindGameObjectWithTag("Player").transform.localRotation.y > 90)
        //Dir.x = Speed;

        //if (GameObject.FindGameObjectWithTag("Player").transform.localRotation.y < 90)
        //{
        //    Dir.x = -Speed;
        //    Vector3 theScale;
        //    theScale = transform.localScale;
        //    theScale.x *= -1;
        //    this.transform.localScale = theScale;
        //}

        Destroy(gameObject, LifeTime);
        rb2d = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        //transform.position += Dir;
        //print(new Vector2(transform.forward.z, transform.forward.y) * Speed);
        rb2d.AddForce(new Vector2(transform.forward.z, transform.forward.y) * Speed);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Если объект с которым мы столкнулись имеет тег Enemy
        if (collision.gameObject.tag == "Enemy")
        {
            MyEnemy Enemy = collision.gameObject.GetComponent<MyEnemy>();
            // Делаем ссылку на объект противника
            if (Enemy != null) // Если ссылка не пуста
            {
                Enemy.Hurt(Damage); // Вызываем метод урона и указываем его размер
                // Спауним объект, который симулирует взрыв
                Instantiate(BOOM, transform.position, transform.rotation);
                //m_MyAudioSource.Play();

                // Уничтожаем пулю
                Destroy(gameObject);
            }
        }
    }
}
