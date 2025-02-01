using UnityEngine;
using System.Collections;

public class SpeedMeter : MonoBehaviour
{
    public enum SpeedLevel
    {
        Green,
        Yellow,
        Red,
        Boost
    }

    [SerializeField] private PlayerMovement playerScript;
    [SerializeField] private Transform needleTransform;
    [SerializeField] private float meterIncreasePerMash = 2.5f;
    [SerializeField] private float meterDecreaseRate = 2f; // Rate at which the meter decreases per second
    [SerializeField] private float greenSpeedMultiplier = 1f;
    [SerializeField] private float yellowSpeedMultiplier = 1.5f;
    [SerializeField] private float redSpeedMultiplier = 2f;
    [SerializeField] private float boostSpeedMultiplier = 3f;

    private SpeedLevel currentLevel = SpeedLevel.Green;
    private float currentRotation = 55f;
    private float baseSpeed;
    private float normalMeterIncreasePerMash;
    private bool isSpeedBoosted = false;
    private LevelManager levelManager;
    private AudioManager audioManager;

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        baseSpeed = playerScript._Yoko_speed;
        normalMeterIncreasePerMash = meterIncreasePerMash;
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        CheckSpacebarMash();
        DecreaseMeter();
        UpdateMeter();
        CheckLevelChange();
    }

    private void CheckSpacebarMash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && levelManager.gameStarted)
        {
            currentRotation -= meterIncreasePerMash;
        }
    }

    private void DecreaseMeter()
    {
        currentRotation += meterDecreaseRate * Time.deltaTime;
    }

    private void UpdateMeter()
    {
        currentRotation = Mathf.Clamp(currentRotation, -55f, 55f);
        needleTransform.rotation = Quaternion.Euler(0, 0, currentRotation);
    }

    private void CheckLevelChange()
    {
        SpeedLevel newLevel;

        if (currentRotation <= -53f && isSpeedBoosted)
        {
            newLevel = SpeedLevel.Boost;
        }
        else if (currentRotation <= -17f)
        {
            newLevel = SpeedLevel.Red;
        }
        else if (currentRotation <= 20f)
        {
            newLevel = SpeedLevel.Yellow;
        }
        else
        {
            newLevel = SpeedLevel.Green;
        }

        if (newLevel != currentLevel)
        {
            ChangeLevel(newLevel);
        }
    }

    private void ChangeLevel(SpeedLevel newLevel)
    {
        currentLevel = newLevel;
        UpdatePlayerSpeed();
    }

    public void HitObstacle()
    {
        if (currentLevel == SpeedLevel.Yellow)
        {
            currentRotation = 55f;
        }
        else if (currentLevel == SpeedLevel.Red || currentLevel == SpeedLevel.Boost)
        {
            currentRotation = 17f;
        }
        CheckLevelChange();
    }

    private void UpdatePlayerSpeed()
    {
        float speedMultiplier = currentLevel switch
        {
            SpeedLevel.Green => greenSpeedMultiplier,
            SpeedLevel.Yellow => yellowSpeedMultiplier,
            SpeedLevel.Red => redSpeedMultiplier,
            SpeedLevel.Boost => boostSpeedMultiplier,
            _ => greenSpeedMultiplier
        };

        playerScript._Yoko_speed = baseSpeed * speedMultiplier;
    }

    public void ActivateSpeedBoost(float duration)
    {
        audioManager.PlaySFX(audioManager.speedSound);
        if (!isSpeedBoosted)
        {
            StartCoroutine(SpeedBoostCoroutine(duration));
        }
        else
        {
            StopCoroutine(SpeedBoostCoroutine(duration));
            StartCoroutine(SpeedBoostCoroutine(duration));
        }
    }

    private IEnumerator SpeedBoostCoroutine(float duration)
    {
        isSpeedBoosted = true;
        meterIncreasePerMash *= 2;
        CheckLevelChange();

        yield return new WaitForSeconds(duration);

        meterIncreasePerMash = normalMeterIncreasePerMash;
        isSpeedBoosted = false;
        CheckLevelChange();
    }
}
