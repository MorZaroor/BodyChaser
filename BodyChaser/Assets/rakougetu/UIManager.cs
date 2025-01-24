using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject PopupPanel;      // ������� Panel
    public GameObject MainButtons;    // ������İ�ť����

    void Start()
    {
        // ��ʼ��ʱ���ص�����
        if (PopupPanel != null)
        {
            PopupPanel.SetActive(false);
        }
    }

    // ��ʾ������
    public void ShowPopup()
    {
        if (PopupPanel != null)
        {
            PopupPanel.SetActive(true);
        }
    }

    // �رյ�����
    public void ClosePopup()
    {
        if (PopupPanel != null)
        {
            PopupPanel.SetActive(false);
        }
    }

    // ���ذ�ť���߼�
    public void ReturnToMenu()
    {
        ClosePopup();  // �رյ�����
        // ��ӷ��ص����˵����߼�
    }

    // ������ť���߼�
    public void ContinueGame()
    {
        ClosePopup();  // �رյ�����
        // ��Ӽ�����Ϸ���߼�
    }
}
