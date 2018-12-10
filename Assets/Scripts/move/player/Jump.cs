using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float jumpForce;
    public LayerMask groundLayer;

    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update() {

        // прыжок
        if (Input.GetKeyDown(KeyCode.Space))
            jump();
    }

    /// <summary>
    /// Метод прыжка
    /// </summary>
    void jump()
    {
        if (!IsGrounded())
            return;
        else
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
            return true;

        return false;
    }
}