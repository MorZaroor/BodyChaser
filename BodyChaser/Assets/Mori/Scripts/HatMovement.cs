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

}
