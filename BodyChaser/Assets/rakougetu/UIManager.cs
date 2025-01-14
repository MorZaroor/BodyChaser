using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject PopupPanel;      
    public GameObject MainButtons;    

    void Start()
    {
        
        if (PopupPanel != null)
        {
            PopupPanel.SetActive(false);
        }
    }

   
    public void ShowPopup()
    {
        if (PopupPanel != null)
        {
            PopupPanel.SetActive(true);
        }

    }

   
    public void ClosePopup()
    {
        if (PopupPanel != null)
        {
            PopupPanel.SetActive(false);
        }
    }

   
    public void ReturnToMenu()
    {
        ClosePopup();  
        
    }

    
    public void ContinueGame()
    {
        ClosePopup(); 
        
    }
}
