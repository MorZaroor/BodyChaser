using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject PopupPanel;      // 弹出框的 Panel
    public GameObject MainButtons;    // 主界面的按钮容器

    void Start()
    {
        // 初始化时隐藏弹出框
        if (PopupPanel != null)
        {
            PopupPanel.SetActive(false);
        }
    }

    // 显示弹出框
    public void ShowPopup()
    {
        if (PopupPanel != null)
        {
            PopupPanel.SetActive(true);
        }
    }

    // 关闭弹出框
    public void ClosePopup()
    {
        if (PopupPanel != null)
        {
            PopupPanel.SetActive(false);
        }
    }

    // 返回按钮的逻辑
    public void ReturnToMenu()
    {
        ClosePopup();  // 关闭弹出框
        // 添加返回到主菜单的逻辑
    }

    // 继续按钮的逻辑
    public void ContinueGame()
    {
        ClosePopup();  // 关闭弹出框
        // 添加继续游戏的逻辑
    }
}
