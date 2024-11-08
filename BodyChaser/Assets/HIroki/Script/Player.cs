using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField, Header("ˆÚ“®‘¬“x")]
    private float _speed;

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
    }

    private void _Move()
    {
        _rigid.velocity = _inputVelocity * _speed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _inputVelocity =context.ReadValue<Vector2>();
    }
}
