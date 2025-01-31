using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
public class GameManager : MonoBehaviour
{
    // 游戏总时间
    //public float totalGameTime = 60f;
    // 游戏是否结束
    //private bool isGameOver = false;
    // 是否胜利
    /*private bool isVictory = false;
    // 胜利画面预制体
    public GameObject victoryScreenPrefab;
    // 失败画面预制体
    public GameObject defeatScreenPrefab;
    // 显示GIF的Image组件的RectTransform
    public RectTransform gifImageRectTransform;
    // GIF移动速度
    public float moveSpeed = 5f;
    */
    // 返回按钮
    public GameObject returnButton;
    private void Start()
    {
        ShowResultScreen();
    }
    /*void Update()
    {
        if (!isGameOver)
        {
            totalGameTime -= Time.deltaTime;
            if (totalGameTime <= 0)
            {
                isGameOver = true;
                //isVictory = false;
                ShowResultScreen();
            }
        }
    }*/
    // 角色到达终点调用此方法
    /*public void OnKeyItemTouched()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            isVictory = true;
            ShowResultScreen();
        }
    }*/
    void ShowResultScreen()
    {
        //GameObject resultScreen = isVictory ? Instantiate(victoryScreenPrefab) : Instantiate(defeatScreenPrefab);
        // 启动GIF显示逻辑
        //MoveGifImage();
        // 延迟显示返回按钮
        Invoke(nameof(ShowReturnButton), 3f);
    }
    /*void MoveGifImage()
    {
        if (gifImageRectTransform != null)
        {
            StopCoroutine(MoveGif());
            StartCoroutine(MoveGif());
        }
    }*/
    /*IEnumerator MoveGif()
    {
        while (true)
        {
            gifImageRectTransform.anchoredPosition += new Vector2(moveSpeed * Time.deltaTime, 0f);
            yield return null;
        }
    }*/
    void ShowReturnButton()
    {
        if (returnButton != null)
        {
            returnButton.SetActive(true);
        }
    }
    // 返回标题场景
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("startv2");
    }
}