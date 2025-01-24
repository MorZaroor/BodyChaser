using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoalTransform : MonoBehaviour
{
    //Playerの位置と右端の位置の中間　50秒間
    //右端に進む　50秒間後

    public GameObject left;
    public GameObject right;
    float math; //位置計算結果
    float pos;  //ゴールの位置
    Vector3 left_pos;
    Vector3 right_pos;
    GameOverCount gameovercount;

    void Start()
    {
        //スプリクト取得
        gameovercount = gameObject.GetComponent<GameOverCount>();
    }

    void Update()
    {
        right_pos = right.transform.position;
        this.transform.DOMove(new Vector3(right_pos.x, -4.4f, 0f), 85f);
    }

    //Updateの中身
    /*if(gameovercount.count <= 50)
        {
            FirstLocation();
            Condition();
            GoalPos();
        }
        else if(gameovercount.count >= 50 && gameovercount.count <= gameovercount.Limit)
        {
            SecondLocation();
        }*/


    /*private void FirstLocation()
    {
        left_pos = left.transform.position;
        right_pos = right.transform.position;

        math = (Mathf.Abs(left_pos.x) - right_pos.x);
    }

    private void SecondLocation()
    {
        this.transform.DOMove(new Vector3(right_pos.x,-4.4f,0f),20f);
    }

    private void GoalPos()
    {
        Vector3 position = transform.position;
        position.x = pos;
        transform.position = position;
    }

    private void Condition()//ゴールの移動する位置　条件
    {
        if (left_pos.x < 1)
        {
            if (math < -0.5 && math >= -6.5)
            {
                pos = Mathf.Abs(math);
            }
            else if (math > -0.5)
            {
                math = -0.5f;
                pos = Mathf.Abs(math);
            }
            else if (math <= -6.5)
            {
                math = -6.5f;
                pos = Mathf.Abs(math);
            }
        }
        else
        {
            math = -6.5f;
            pos = Mathf.Abs(math);
        }*/

}
