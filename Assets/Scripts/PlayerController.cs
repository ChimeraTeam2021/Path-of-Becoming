using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed;
    public float jumpForce;

    private float moveImput;
    private Rigidbody2D rb;
    
    private bool faceRight = true;
    public bool isGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJump;
    public int extraJampValue;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJump = extraJampValue;
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveImput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveImput * speed, rb.velocity.y);

        if(faceRight == false && moveImput > 0)
        {
            Flip();
        }
        else if(faceRight == true && moveImput < 0)
        {
            Flip();
        }

        if (isGround == true)
        {
            extraJump = extraJampValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGround == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
