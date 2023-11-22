using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;

    public Coin coin;
    public GameManager gameManager;
    public Animator animator;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private bool isGrounded = true;
    private bool isSlide = false;

    private Rigidbody rb;
    
    void Start()
    {
        coin = GameObject.Find("coin").GetComponent<Coin>();
        rb = GetComponent<Rigidbody>();
    }

 
    void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("Jump", false);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameManager.GameOver();
        }

    }

    public void Move()
    {
        if (gameManager.isStart)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");


            transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.4f, 1.4f), transform.position.y, -5);

            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded && !isSlide)
            {
                rb.AddForce(Vector3.up * jumpForce);
                animator.SetBool("Jump", true);
                isGrounded = false;

            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded && !isSlide)
            {
                animator.SetBool("Slide", true);
                isSlide = true;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                animator.SetBool("Slide", false);
                isSlide = false;
            }
        }

    }

}
