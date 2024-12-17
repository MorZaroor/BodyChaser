using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMath : MonoBehaviour
{
    public Text asobikataText; 
    public Button ReturnButton; 
    public Button CoutinueButton;

    private int currentPage = 0;
    private string[] hints;

    void Start()
    {
        hints = new string[]
        {
            "kata1",
            "kata2",
            "kata3",
            "kata4"
        };


        UpdateHintText();


        ReturnButton.onClick.AddListener(ShowPreviousPage);
        CoutinueButton.onClick.AddListener(ShowNextPage);


        UpdateButtonStates();
    }


    void UpdateHintText()
    {
        if (currentPage >= 0 && currentPage < hints.Length)
        {
            asobikataText.text = hints[currentPage];
        }
    }


    void ShowPreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            UpdateHintText();
            UpdateButtonStates();
        }
    }


    void ShowNextPage()
    {
        if (currentPage < hints.Length - 1)
        {
            currentPage++;
            UpdateHintText();
            UpdateButtonStates();
        }
    }


    void UpdateButtonStates()
    {
        ReturnButton.interactable = currentPage > 0;
        CoutinueButton.interactable = currentPage < hints.Length - 1;
    }
}

