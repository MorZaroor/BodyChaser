using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.CompilerServices;

public class GoalManager : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float accelerationRate = 0.1f;
    public float maxSpeed = 15f;
    public float catchDistance = 2f;
    public float gameTime = 100f;
    public Transform playerTransform;
    private float currentSpeed;
    public float timer;
    public bool iscount = false;
    public TextMeshProUGUI timerText;

    void Start()
    {
        currentSpeed = baseSpeed;
        timer = gameTime;
    }

    void Update()
    {
        transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
        currentSpeed = Mathf.Min(currentSpeed + accelerationRate * Time.deltaTime, maxSpeed);

        if (playerTransform.position.x >= transform.position.x - catchDistance)
        {
            GameClear();
        }

        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F2");
        if (timer <= 0)
        {
            GameOver();
        }
        if (timer >= 50 && timer <= 53)
        {
            iscount = true;
        }
        else
        {
            iscount = false;
        }
    }

    void GameClear()
    {
        SceneManager.LoadScene("GameClear");
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
