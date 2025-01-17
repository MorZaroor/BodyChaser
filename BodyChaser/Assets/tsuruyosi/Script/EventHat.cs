using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHat : MonoBehaviour
{
    public GameOverCount gameovercount;
    public GameObject hat;
    //帽子生成時間　管理
    public float count;
    public bool isHat;
    //PlayerのY座標を入れる変数
    public float play_y;

    void Start()
    {
        //Goalのobjを取得
        GameObject obj = GameObject.Find("Goal");
        //スプリクト取得
        gameovercount = obj.GetComponent<GameOverCount>();
    }

    // Update is called once per frame
    void Update()
    {
        HatTime();
        if(gameovercount.count >= 50 && gameovercount.count <= 90)
        {
            if(isHat == true)
            {
                Hatmanage();
            }
        }
    }

    public void HatTime()
    {
        count += Time.deltaTime;
        if (count >= 5)
        {
            isHat = true;
            count = 0;
        }
        else
        {
            isHat = false;
        }
    }

    public void Hatmanage()
    {
        //PlayerのY座標に合わせて生成
        Vector3 play = GameObject.Find("Player").transform.position;
        play_y = play.y;
        Instantiate(hat, new Vector3(8.0f, play_y, 0.0f), Quaternion.identity);
    }
}
