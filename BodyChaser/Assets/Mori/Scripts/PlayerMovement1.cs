using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement1 : MonoBehaviour //name change
{
    [SerializeField, Header("�c�̈ړ����x")]
    private float _Tate_speed;
    [SerializeField, Header("���̈ړ����x")]
    public float _Yoko_speed;

    // Start is called before the first frame update
    void Start()
    {
        // 120fps��ڕW�ɐݒ�
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * _Yoko_speed;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * _Tate_speed;

        transform.position = new Vector2(
            transform.position.x,
            Mathf.Clamp(transform.position.y + moveY, -8.5f, 8.5f)
        );
        transform.position += Vector3.right * _Yoko_speed * Time.deltaTime;
    }
}
