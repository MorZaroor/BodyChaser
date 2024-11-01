using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float verticalSpeed = 5f;
    public float accelerationMultiplier = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float verticalMovement = Input.GetAxis("Vertical") * verticalSpeed;
        float horizontalMovement = moveSpeed;

        if (Input.GetKey(KeyCode.Space))
        {
            horizontalMovement *= accelerationMultiplier;
        }

        rb.velocity = new Vector2(horizontalMovement, verticalMovement);
    }
}
