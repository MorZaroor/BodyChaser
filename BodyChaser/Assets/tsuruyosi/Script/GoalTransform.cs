using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float moveDuration = 20f;  // 20秒間で移動する
    private Vector3 startPosition;  // 初期位置
    public GameOverCount time;

    void Start()
    {
        //スプリクト取得
        time = gameObject.GetComponent<GameOverCount>();
    }

    void Update()
    {
        if(time.count <= 50)
        {
            FirstLocation();
            Condition();
            GoalPos();
        }
        else if(time.count > 50 && time.count <= 70)
        {
            SecondLocation();
            GoalPos();
        }
    }

    private void FirstLocation()
    {
        left_pos = left.transform.position;
        right_pos = right.transform.position;

        math = (Mathf.Abs(left_pos.x) - right_pos.x);
        Debug.Log(math);
    }

    private void SecondLocation()
    {
        startPosition = transform.position;
        float timeElapsed = time.count-50;                                                                                                                                                                                                                                                          
        if(timeElapsed <= moveDuration)
        {
            float t = timeElapsed / moveDuration; // 0から1の間で進行具合を計算
            // 画面座標からワールド座標に変換
            Vector3 worldEndPosition = Camera.main.ScreenToWorldPoint(right_pos);
            worldEndPosition.z = transform.position.z; // Z軸はそのままにする
            transform.position = Vector3.Lerp(startPosition, worldEndPosition, t);
        }
        else
        {
            // 終了時間に達したら、右端に固定
            transform.position = Camera.main.ScreenToWorldPoint(right_pos);
            transform.position = new Vector3
                (transform.position.x, startPosition.y, transform.position.z);
        }
    }

    private void GoalPos()
    {
        Vector3 position = transform.position;
        position.x = pos;
        transform.position = position;
    }

    private void Condition()
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
        }

    }//ゴールの移動する位置　条件


}
