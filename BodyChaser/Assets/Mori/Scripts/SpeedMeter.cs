using System.Collections;
using UnityEngine;

public class SpeedMeter : MonoBehaviour
{
    public enum SpeedLevel
    {
        Green,
        Yellow,
        Red
    }

    [SerializeField] private PlayerMovement playerScript;
    [SerializeField] private Transform needleTransform;
    [SerializeField] private float meterIncreaseSpeed = 10f;
    [SerializeField] private float greenSpeedMultiplier = 1f;
    [SerializeField] private float yellowSpeedMultiplier = 1.5f;
    [SerializeField] private float redSpeedMultiplier = 2f;

    private SpeedLevel currentLevel = SpeedLevel.Green;
    private float currentRotation = 55f;
    private float baseSpeed;
    private float normalMeterIncreaseSpeed;
    private bool isSpeedBoosted = false;

    private void Start()
    {
        baseSpeed = playerScript._Yoko_speed;
        normalMeterIncreaseSpeed = meterIncreaseSpeed;
    }

    private void Update()
    {
        UpdateMeter();
        CheckLevelAdvance();
    }

    private void UpdateMeter()
    {
        if (currentLevel == SpeedLevel.Green && currentRotation > 20f)
        {
            currentRotation -= meterIncreaseSpeed * Time.deltaTime;
        }
        else if (currentLevel == SpeedLevel.Yellow && currentRotation > -17f)
        {
            currentRotation -= meterIncreaseSpeed * Time.deltaTime;
        }
        else if (currentLevel == SpeedLevel.Red && currentRotation > -55f)
        {
            currentRotation -= meterIncreaseSpeed * Time.deltaTime;
        }

        needleTransform.rotation = Quaternion.Euler(0, 0, currentRotation);
    }

    private void CheckLevelAdvance()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentLevel == SpeedLevel.Green && currentRotation <= 20f)
            {
                AdvanceToLevel(SpeedLevel.Yellow);
            }
            else if (currentLevel == SpeedLevel.Yellow && currentRotation <= -17f)
            {
                AdvanceToLevel(SpeedLevel.Red);
            }
        }
    }

    private void AdvanceToLevel(SpeedLevel newLevel)
    {
        currentLevel = newLevel;
        UpdatePlayerSpeed();

        switch (newLevel)
        {
            case SpeedLevel.Yellow:
                currentRotation = 17f;
                break;
            case SpeedLevel.Red:
                currentRotation = -20f;
                break;
        }
    }

    public void HitObstacle()
    {
        if (currentLevel == SpeedLevel.Yellow)
        {
            AdvanceToLevel(SpeedLevel.Green);
            currentRotation = 55f;
        }
        else if (currentLevel == SpeedLevel.Red)
        {
            AdvanceToLevel(SpeedLevel.Yellow);
            currentRotation = 17f;
        }
    }

    private void UpdatePlayerSpeed()
    {
        float speedMultiplier = currentLevel switch
        {
            SpeedLevel.Green => greenSpeedMultiplier,
            SpeedLevel.Yellow => yellowSpeedMultiplier,
            SpeedLevel.Red => redSpeedMultiplier,
            _ => greenSpeedMultiplier
        };

        playerScript._Yoko_speed = baseSpeed * speedMultiplier;
    }

    public void ActivateSpeedBoost(float duration)
    {
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
        meterIncreaseSpeed *= 2;

        yield return new WaitForSeconds(duration);

        meterIncreaseSpeed = normalMeterIncreaseSpeed;
        isSpeedBoosted = false;
    }
}
