using UnityEngine;
using UnityEngine.UI;

public class PlayMathv2 : MonoBehaviour
{
    public Image asobikataImage;
    public Button previousButton;
    public Button nextButton;
    public Sprite[] asobikataSprites;

    private int currentPage = 0;

    void Start()
    {
        previousButton.onClick.AddListener(ShowPreviousPage);
        nextButton.onClick.AddListener(ShowNextPage);
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        asobikataImage.sprite = asobikataSprites[currentPage];
        previousButton.gameObject.SetActive(currentPage > 0);
        nextButton.gameObject.SetActive(currentPage < asobikataSprites.Length - 1);
    }

    void ShowPreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            UpdateDisplay();
        }
    }

    void ShowNextPage()
    {
        if (currentPage < asobikataSprites.Length - 1)
        {
            currentPage++;
            UpdateDisplay();
        }
    }
}
