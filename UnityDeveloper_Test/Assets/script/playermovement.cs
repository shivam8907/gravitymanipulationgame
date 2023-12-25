using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Animator animator;

    public GameObject hologram;  // Reference to the hologram object

    private Rigidbody rb;
    private Vector3 gravityDirection = Vector3.down;  // Initial gravity direction

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        UpdateHologram();  // Initialize the hologram
        // Add Animator component reference
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();
        Jump();
        HandleGravityManipulation();
        bool isRunning = Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f;
        animator.SetBool("IsRunning", isRunning);
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.Self);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void HandleGravityManipulation()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gravityDirection = Vector3.forward;
            UpdateHologram();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gravityDirection = Vector3.back;
            UpdateHologram();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gravityDirection = Vector3.left;
            UpdateHologram();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gravityDirection = Vector3.right;
            UpdateHologram();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ManipulateGravity();
        }
    }

    void UpdateHologram()
    {
        hologram.transform.rotation = Quaternion.LookRotation(gravityDirection, Vector3.up);
        hologram.SetActive(true);
    }

    void ManipulateGravity()
    {
        Physics.gravity = -gravityDirection * 9.8f;  // Adjust the gravity strength if needed
        hologram.SetActive(false);
    }

  /*  bool IsGrounded()
    {
        float rayLength = 0.1f;
        return Physics.Raycast(transform.position, Vector3.down, rayLength);
    }*/
}
