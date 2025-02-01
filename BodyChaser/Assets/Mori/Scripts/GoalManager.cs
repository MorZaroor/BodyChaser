using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

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
    private Coroutine alarmCoroutine;
    private bool bgmChanged = false;
    public TextMeshProUGUI timerText;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        currentSpeed = baseSpeed;
        timer = gameTime;
        alarmCoroutine = StartCoroutine(PlayAlarmAt53Seconds());
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
    }

    IEnumerator PlayAlarmAt53Seconds()
    {
        yield return new WaitUntil(() => timer <= 53 && timer > 50);
        audioManager.ChangeBGM(audioManager.eventSound);
        iscount = true;
        yield return new WaitForSeconds(3);
        iscount = false;
        audioManager.ChangeBGM(audioManager.midGameBGM);
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
