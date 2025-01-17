using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatEvent : MonoBehaviour
{
    public GameObject hatPrefab;
    public GoalManager goalManager;
    //帽子生成時間　管理
    public float count;
    public bool isHat;
    //PlayerのY座標を入れる変数
    public float play_y;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HatTime();
        if (goalManager.timer <= 50 && goalManager.timer >= 10)
        {
            if (isHat == true)
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
        Instantiate(hatPrefab, new Vector3(8.0f, play_y, 0.0f), Quaternion.identity);
    }
}
