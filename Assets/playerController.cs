using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float Acceleration; // Скорость движения, а в дальнейшем ускорение
    public float jumpForce;
    public GameObject Bullet; // Наш снаряд, которым будем стрелять
    public GameObject StartBullet; // И точка, где он создается
    private Vector3 Dir = new Vector3(0, 0, 0);// Направление движения
    private bool facingRight = true;
    private Vector3 theScale;
    private Animator anim;
    private Rigidbody2D rb2d;
    public LayerMask groundLayer;

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

    void Awake()
    {
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
            Dir.x = Input.GetAxis("Horizontal");
        else
            Dir.x = 0;

        
		// If the input is moving the player right and the player is facing left...
        if (Input.GetAxis("Horizontal") > 0 && !facingRight)
        {
            facingRight = !facingRight;
            theScale = this.transform.localScale;
            theScale.x *= -1;
            Debug.Log(theScale);
            this.transform.localScale = theScale;
        }

        if (Input.GetAxis("Horizontal") < 0 && facingRight)
        {
            facingRight = !facingRight;
            theScale = transform.localScale;
            theScale.x *= -1;
            Debug.Log(theScale);
            this.transform.localScale = theScale;
        }
        
        //transform.position += Dir * Acceleration;




        // Передаем нашему transform движение
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bullet, StartBullet.transform.position, transform.rotation);
        }
        
        //if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        //{
        //    //anim?.SetTrigger("Walk");
        //    print("the debug text displays");
        //    //anim?.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        //}


        //rb2d.AddForce(Vector2.right * h * moveForce);

        //rb2d.AddForce(new Vector2(Dir.x * Acceleration, Dir.y));
        rb2d.AddForce(Vector2.right * Input.GetAxis("Horizontal") * Acceleration);
        

        //this.transform.localScale.Set(theScale);
        //Debug.Log(transform.localScale);

        //Vector3 scale = this.transform.localScale;
        //scale.Set(theScale.x, theScale.y, theScale.z);
        //Debug.Log(scale);

       // this.transform.localScale.Set(theScale.x, theScale.y, theScale.z);



        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }



       // Debug.Log(this.transform.localScale);
        //Debug.Log(theScale);

    }

    void Jump()
    {
        if (!IsGrounded())
        {
            return;
        }
        else
        {
            print("the debug text displays");
            anim?.SetTrigger("Jump");
            //jumping = true;
            rb2d.velocity = new Vector2(0, jumpForce);
        }
    }
}
