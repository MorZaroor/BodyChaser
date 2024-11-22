using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCount : MonoBehaviour
{
    [SerializeField] float Limit = 70; //GameOverまでの時間
    float count;    //時間カウント

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
        }
    }

    private void OverLimit()
    {
        //時間カウント
        count += Time.deltaTime;

        if(count >= Limit)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
