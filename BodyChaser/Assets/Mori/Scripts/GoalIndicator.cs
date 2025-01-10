using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalIndicator : MonoBehaviour
{
    public Transform playerTransform;
    public Transform goalTransform;
    public RectTransform goalIndicatorRect;
    public TextMeshProUGUI distanceText;
    public float maxDistance = 100f;
    private float startX = -135f;
    private float endX = 135f;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(startX, rectTransform.anchoredPosition.y);
    }

    private void Update()
    {
        UpdateIndicator();
    }

    private void UpdateIndicator()
    {
        float distance = goalTransform.position.x - playerTransform.position.x;
        distanceText.text = $"{Mathf.Max(distance, 0):F1}m";
        float normalizedDistance = Mathf.Clamp01(distance / maxDistance);
        float playerIndicatorX = Mathf.Lerp(startX, endX, 1 - normalizedDistance);
        rectTransform.anchoredPosition = new Vector2(playerIndicatorX, rectTransform.anchoredPosition.y);
    }
}
