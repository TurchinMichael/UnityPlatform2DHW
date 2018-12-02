using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration; // Скорость движения, а в дальнейшем ускорение
    private Vector2 dir = new Vector3(0, 0);// Направление движения
    private Rigidbody2D rb2d;

    private bool facingRight = true;
    private Vector3 theScale;

    public GameObject bullet; // Наш снаряд
    public GameObject startBullet; // точка, где он создается

    public GameObject bombPacket; // бомба
    public GameObject startBomb; // точка, где она создается

    public float jumpForce;
    public LayerMask groundLayer;

    private Animator anim;

    void Start()
    {
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // изменяем направление движения для персонажа с помощью клавиатуры
        dir.x = Input.GetAxis("Horizontal") * acceleration;


        // костыльный разворот спрайта персонажа вправо
        if (dir.x > 0 && !facingRight)
        {
            facingRight = !facingRight;

            theScale = this.transform.localScale;
            theScale.x *= -1;
            this.transform.localScale = theScale;
        }

        // костыльный разворот спрайта персонажа влево
        if (dir.x < 0 && facingRight)
        {
            facingRight = !facingRight;

            theScale = transform.localScale;
            theScale.x *= -1;
            this.transform.localScale = theScale;
        }


        if (dir.x != 0)
        {
            float z = Mathf.Clamp(dir.x, -maxSpeed, maxSpeed);
            rb2d.AddForce(Vector2.right * z, ForceMode2D.Force);


            if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            {
                dir = rb2d.velocity;
                dir.x = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
                rb2d.velocity = dir;
            }

            if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            {
                print("sdfsdfs");
            }
        }



        // стрельба
        if (Input.GetButtonDown("Fire1"))
        {
            fire(bullet, startBullet.transform.position);
        }

        // прыжок
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


        // заложить взрывчатку
        if (Input.GetKeyDown(KeyCode.Z))
        {
            fire(bombPacket, startBomb.transform.position);
        }
    }

    /// <summary>
    /// Метод стреляющий снарядом
    /// </summary>
    /// <param name = "packet" > объект снаряда</param>
    /// <param name = "startForPacket" > позиция создания снаряда</param>
    void fire(GameObject packet, Vector3 startForPacket)
    {
        Instantiate(packet, startForPacket, transform.rotation);
    }

    /// <summary>
    /// Метод отслеживающий стоит ли персонаж на поверхности, от которой можно оттолкнуться
    /// </summary>
    /// <returns></returns>
    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Метод прыжка
    /// </summary>
    void Jump()
    {
        if (!IsGrounded())
        {
            return;
        }
        else
        {
            //anim?.SetTrigger("Jump");
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }


}
