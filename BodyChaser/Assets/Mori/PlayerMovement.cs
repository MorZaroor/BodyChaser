using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float verticalSpeed = 5f;
    public float accelerationMultiplier = 2f;
    public float verticalLimit = 3.5f; // New variable for vertical limit

    private Rigidbody2D rb;
    private bool canMove = true; // New variable to control movement

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!canMove) return;

        float verticalMovement = Input.GetAxis("Vertical") * verticalSpeed;
        float horizontalMovement = moveSpeed;

        if (Input.GetKey(KeyCode.Space))
        {
            horizontalMovement *= accelerationMultiplier;
        }

        // Clamp vertical position
        float newY = Mathf.Clamp(transform.position.y + verticalMovement * Time.deltaTime, -verticalLimit, verticalLimit);

        rb.velocity = new Vector2(horizontalMovement, (newY - transform.position.y) / Time.deltaTime);
    }

    public void StopMovement()
    {
        canMove = false;
        rb.velocity = Vector2.zero;
    }
}