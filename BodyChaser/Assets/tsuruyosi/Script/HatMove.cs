using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatMove : MonoBehaviour
{
    public float moveSpeed = 3f;  // 敵の移動速度
    private Vector2 movementDirection = Vector2.left;  // 左方向に動く

    //Hatを消す間隔
    public float count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
