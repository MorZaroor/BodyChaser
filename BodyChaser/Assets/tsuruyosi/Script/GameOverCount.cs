using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCount : MonoBehaviour
{
    public float Limit = 100; //GameOverまでの時間
    public float count;    //時間カウント
    public bool iscount;    //UIイベント管理

    public GameClear goal;

    void Start()
    {
        //スプリクト取得
        goal = gameObject.GetComponent<GameClear>();
    }

    void Update()
    {
        //ゴールしていない状態の時のみ
        if(goal.Clear == false)
        {
            OverLimit();
            EventIS();
        }
    }

    private void OverLimit()
    {
        //時間カウント
        count += Time.deltaTime;

        if(count >= Limit)
        {
            SceneManager.LoadScene("GameOver");
            count = 0;
        }
    }

    public void EventIS()
    {
        if(count >= 50 && count <= 53)
        {
            iscount = true;
        }else
        {
            iscount = false;
        }
    }

}
