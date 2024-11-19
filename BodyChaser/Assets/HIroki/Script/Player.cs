using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField, Header("ècÇÃà⁄ìÆë¨ìx")]
    private float _tate_speed;
    [SerializeField, Header("â°ÇÃà⁄ìÆë¨ìx")]
    private float _yoko_speed;

    private Vector2 _inputVelocity;
    private Rigidbody2D _rigid;

    // Start is called before the first frame update
    void Start()
    {
        _inputVelocity = Vector2.zero;
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.position = new Vector2(
            transform.position.x,
            Mathf.Clamp(transform.position.y + moveY, -8.5f, 8.5f)
        );
        transform.position += Vector3.right * _yoko_speed * Time.deltaTime;
    }

    private void _Move()
    {
        _rigid.velocity = _inputVelocity * _tate_speed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _inputVelocity =context.ReadValue<Vector2>();
    }
}
