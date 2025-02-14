using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 7.0f;
    public LayerMask groundLayers; 
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
    }

    private void Move()
    {
        float xMovement = Input.GetAxis("Horizontal") * speed;
        float zMovement = Input.GetAxis("Vertical") * speed;

        Vector3 movement = transform.right * xMovement + transform.forward * zMovement;
        Vector3 newPosition = rb.position + movement * Time.deltaTime;
        rb.MovePosition(newPosition);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {       
        return Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);
    }
}
