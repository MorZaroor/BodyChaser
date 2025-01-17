using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatMove : MonoBehaviour
{
    PlayerMovement playerMovement;

    public float moveSpeed = 3f;  // 敵の移動速度
    private Vector2 movementDirection = Vector2.left;  // 左方向に動く

    float Speedcount;

    //Hatを消す間隔
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

    //当たった時Playerのスピードが下がる処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovement.moveSpeed = 3f;
        Speedcount += Time.deltaTime;
        if(Speedcount >= 3)
        {
            playerMovement.moveSpeed = 5f;
            Speedcount = 0;
        }
    }
}
