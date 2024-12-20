using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public float gameTimeLimit = 60.0f;  // 游戏时间限制，单位：秒，可在Unity编辑器中调整
    private bool gameEnded = false;     // 标记游戏是否结束
                                        // 开始时启动倒计时协程
    void Start()
    {
        StartCoroutine(Countdown());
    }
    // 检测与关键物品的碰撞
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("KeyItem") && !gameEnded)
        {
            // 触摸到关键物品，触发胜利条件，停止倒计时
            gameEnded = true;
            StopCoroutine(Countdown());
            Victory();
        }
    }
    // 游戏时间倒计时协程
    IEnumerator Countdown()
    {
        float timeLeft = gameTimeLimit;
        while (timeLeft > 0 && !gameEnded)
        {
            timeLeft -= Time.deltaTime;
            yield return null;
        }
        if (!gameEnded)
        {
            // 时间结束，触发失败条件
            gameEnded = true;
            Defeat();
        }
    }
    // 胜利处理函数
    void Victory()
    {
        // 这里假设你有一个名为"VictoryAnimation"的动画在名为"UIManager"的物体上，播放胜利结算动画
        GameObject.Find("UIManager").GetComponent<Animator>().Play("VictoryAnimation");
    }
    // 失败处理函数
    void Defeat()
    {
        // 同样假设在"UIManager"物体上有"DefeatAnimation"动画，播放失败结算动画
        GameObject.Find("UIManager").GetComponent<Animator>().Play("DefeatAnimation");
    }
}