using System.Collections.Generic;
using UnityEngine;

public class LevelManager1 : MonoBehaviour //name change
{
    public GameObject[] sectionPrefabs;
    public float sectionWidth = 20f;
    public int totalSections = 5;
    public Transform player; // Reference to the player's transform

    private List<GameObject> activeSections = new List<GameObject>();
    private float totalLevelWidth;
    private Vector3 initialPlayerPosition;

    void Start()
    {
        GenerateLevel();
        initialPlayerPosition = player.position;
    }

    void Update()
    {
        // Check if player has reached the end
        if (player.position.x - initialPlayerPosition.x >= totalLevelWidth - sectionWidth)
        {
            Debug.Log("Reached the end of the level!");
            // You can add end-of-level logic here
        }
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
}