using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;

    public float maxSpeed;
    public float acceleration; // Скорость движения, а в дальнейшем ускорение
    private Rigidbody2D rb2d;

    private bool facingRight = true;
    //private Vector3 theScale;
    Vector3 mousePos;
    Vector3 myPos;

   // public GameObject bullet; // Наш снаряд
   // public GameObject startBullet; // точка, где он создается

    //public float jumpForce;
    //public LayerMask groundLayer;

    private Animator anim;
    bool isFoward = true;

    public bool IsFoward
    {
        get { return isFoward; }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // изменяем направление движения для персонажа с помощью клавиатуры
        dir.x = Input.GetAxis("Horizontal") * acceleration;

        mousePos = Input.mousePosition;
        myPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos = mousePos - myPos;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (Mathf.Abs(angle) > 90)
        {
            angle = 180;
            isFoward = false;
        }
        else
        {
            angle = 0;
            isFoward = true;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));

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
        
        //// прыжок
        //if (Input.GetKeyDown(KeyCode.Space))
        //    Jump();
        
    }


    ///// <summary>
    ///// Метод отслеживающий стоит ли персонаж на поверхности, от которой можно оттолкнуться
    ///// </summary>
    ///// <returns></returns>
    //bool IsGrounded()
    //{
    //    Vector2 position = transform.position;
    //    Vector2 direction = Vector2.down;
    //    float distance = 1.0f;

    //    RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
    //    if (hit.collider != null)
    //        return true;

    //    return false;
    //}

    ///// <summary>
    ///// Метод прыжка
    ///// </summary>
    //void Jump()
    //{
    //    if (!IsGrounded())
    //        return;
    //    else
    //        rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    //}
}
