using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public GameObject[] sectionPrefabs;
    public float sectionWidth = 20f;
    public int totalSections = 5;
    public Transform player; // Reference to the player's transform

    private List<GameObject> activeSections = new List<GameObject>();
    private float totalLevelWidth;
    private Vector3 initialPlayerPosition;

    public TextMeshProUGUI countdownText; // Reference to the UI Text component for the countdown
    public bool gameStarted = false;

    void Start()
    {
        GenerateLevel();
        initialPlayerPosition = player.position;
        StartCoroutine(StartCountdown());
    }

    void Update()
    {

    }

    void GenerateLevel()
    {
        float currentX = 0f;

        for (int i = 0; i < totalSections; i++)
        {
            int randomIndex = Random.Range(0, sectionPrefabs.Length);
            GameObject newSection = Instantiate(sectionPrefabs[randomIndex], new Vector3(currentX, 0, 0), Quaternion.identity);
            activeSections.Add(newSection);
            currentX += sectionWidth;
        }

        totalLevelWidth = currentX;
    }

    IEnumerator StartCountdown()
    {
        Time.timeScale = 0; // Pause the game
        countdownText.gameObject.SetActive(true);

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1f);
        }

        countdownText.text = "GO!";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.gameObject.SetActive(false);
        Time.timeScale = 1; // Resume the game
        gameStarted = true;
    }
}