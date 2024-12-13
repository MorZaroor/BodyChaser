using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float gameTimeLimit = 60f; // 游戏总时长，可按需调整
    private float currentGameTime;
    public bool hasTouchedKeyItem = false; // 是否触摸到关键物品
    public GameObject keyItem; // 关键物品对象引用
    public GameObject gameOverAnimatorObject; // 游戏结算动画对象引用
    public GameObject returnButtonObject; // 返回按钮对象引用
    private Animator gameOverAnimator; // 结算动画组件引用
    void Start()
    {
        currentGameTime = 0f;
        gameOverAnimator = gameOverAnimatorObject.GetComponent<Animator>();
    }

    void Update()
    {
        currentGameTime += Time.deltaTime;
        // 检测人物是否触摸到关键物品（假设通过碰撞检测）
        if (CheckPlayerTouchKeyItem())
        {
            hasTouchedKeyItem = true;
        }
        // 判断游戏是否结束
        if (currentGameTime >= gameTimeLimit || hasTouchedKeyItem)
        {
            EndGame();
        }
    }
    bool CheckPlayerTouchKeyItem()
    {
        // 获取人物碰撞体组件（假设人物脚本中有获取碰撞体的方法）
        Collider playerCollider = GetComponent<PlayerController>().GetPlayerCollider();
        // 检测人物碰撞体与关键物品碰撞体是否接触
        Collider[] colliders = Physics.OverlapSphere(keyItem.transform.position, 0.5f);
        foreach (Collider collider in colliders)
        {
            if (collider == playerCollider)
            {
                return true;
            }
        }
        return false;
    }
 public class PlayerController : MonoBehaviour
    {
        private Collider playerCollider;
        void Start()
        {
            playerCollider = GetComponent<Collider>();
        }
        public Collider GetPlayerCollider()
        {
            return playerCollider;
        }
        // 这里可以添加人物的其他控制逻辑，如移动、跳跃等
    }
    void EndGame()
    {
        bool isWin = hasTouchedKeyItem;
        // 根据胜负设置结算动画参数并播放动画
        gameOverAnimator.SetBool("IsWin", isWin);
        gameOverAnimator.Play("GameOverAnimation");
        // 启动协程等待动画结束后显示返回按钮
        StartCoroutine(ShowReturnButtonAfterAnimation());
    }
    IEnumerator ShowReturnButtonAfterAnimation()
    {
        // 等待结算动画播放完成
        while (gameOverAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            yield return null;
        }
        // 显示返回按钮
        returnButtonObject.SetActive(true);
    }
    public void OnReturnButtonClick()
    {
        // 加载主场景回到主页面（假设主场景名为 "MainScene"）
        SceneManager.LoadScene("MainScene");
    }
}
