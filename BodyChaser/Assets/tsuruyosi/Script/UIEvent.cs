using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvent : MonoBehaviour
{
    public GameOverCount gameovercount;
    public GameObject objectToShow;

    // 点滅させる対象
    [SerializeField] private Renderer _target;
    //点滅周期[s]
    [SerializeField] private float _cycle = 1;
    // 明滅のデューティ比(1で完全にON、0で完全にOFF)
    [SerializeField, Range(0, 1)] private float _dutyRate = 0.5f;
    private double _time;

    void Start()
    {
        //Goalのobjを取得
        GameObject obj = GameObject.Find("Goal");
        //スプリクト取得
        gameovercount = obj.GetComponent<GameOverCount>();
        //objct非表示
        objectToShow.SetActive(false);
    }

    void Update()
    {
        UIDisplay();
    }

    private void UIDisplay()
    {
        if (gameovercount.iscount == true)
        {
            //objct表示
            objectToShow.SetActive(true);
            UIFlashing();
        }
        else if (gameovercount.iscount == false)
        {
            //objct非表示
            objectToShow.SetActive(false);
        }
    }
    private void UIFlashing()
    {
        // 内部時刻を経過させる
        _time += Time.deltaTime;

        // 周期cycleで繰り返す値の取得
        // 0～cycleの範囲の値が得られる
        var repeatValue = Mathf.Repeat((float)_time, _cycle);

        // 内部時刻timeにおける明滅状態を反映
        // デューティ比でON/OFFの割合を変更している
        _target.enabled = repeatValue >= _cycle * (0.8 - _dutyRate);
    }
}
