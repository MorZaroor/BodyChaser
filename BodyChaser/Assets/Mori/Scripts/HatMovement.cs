using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatMovement : MonoBehaviour
{
    PlayerMovement playerMovement;

    public float moveSpeed = 3f;  // �G�̈ړ����x
    private Vector2 movementDirection = Vector2.left;  // �������ɓ���

    float Speedcount;

    //Hat�������Ԋu
    public float count;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();

    }

    void Update()
    {
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
        count += Time.deltaTime;
        if(count >= 15)
        {
            Destroy(gameObject);
            count = 0;
        }
    }

    //����������Player�̃X�s�[�h�������鏈��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovement._Yoko_speed = 3f;
        Speedcount += Time.deltaTime;
        if(Speedcount >= 3)
        {
            playerMovement._Yoko_speed = 5f;
            Speedcount = 0;
        }
    }
}
