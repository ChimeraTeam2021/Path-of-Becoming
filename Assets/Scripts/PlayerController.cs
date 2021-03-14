using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public float MoveInput;
    private Rigidbody2D rb;

    private bool faceRight = true;
    public bool isGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJump;
    public int ExtraJumpValue;

    [SerializeField] GameObject moveButtons;
    [SerializeField] GameObject firstDiaTrigger;
    [SerializeField] float waitTimeTillStart;
    private void Start()
    {
        moveButtons.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        extraJump = ExtraJumpValue;
        StartCoroutine(Wait());
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        // moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveInput * speed, rb.velocity.y);

        if (faceRight == false && MoveInput > 0)
        {
            Flip();
        }
        else if (faceRight == true && MoveInput < 0)
        {
            Flip();
        }

        if (isGround == true)
        {
            extraJump = ExtraJumpValue;
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

    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(waitTimeTillStart);
        firstDiaTrigger.SetActive(true);
    }
    public void OnRightButtonDown()
    {
        MoveInput = 1;
    }
    public void OnLeftButtonDown()
    {
        MoveInput = -1;
    }
    public void OnButtonUp()
    {
        MoveInput = 0;
    }
    public void OnJumpButton()
    {
        if (isGround)
            rb.velocity = Vector2.up * jumpForce;
    }
}
