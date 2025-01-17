using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvent2 : MonoBehaviour
{
    public GameOverCount gameovercount;
    public GameObject objectToShow;

    void Start()
    {
        //Goalのobjを取得
        GameObject obj = GameObject.Find("Goal");
        //スプリクト取得
        gameovercount = obj.GetComponent<GameOverCount>();
        //objct非表示
        objectToShow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UIDisplay2();
    }

    public void UIDisplay2()
    {
        if (gameovercount.count >= 53)
        {
            objectToShow.SetActive(true);
        }else if(gameovercount.count >= 90)
        {
            objectToShow.SetActive(false);
        }
    }
}
