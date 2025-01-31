using System.Collections;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    [SerializeField, Header("無敵時間（秒）")]
    private float invincibilityDuration = 2f;
    [SerializeField, Header("点滅の間隔（秒）")]
    private float flickerInterval = 0.1f;

    private bool isInvincible = false;
    private bool isDamaged = false;
    private SpriteRenderer spriteRenderer;
    public SpeedMeter speedMeter;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") && !isInvincible)
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        Debug.Log("Player took damage!");
        speedMeter.HitObstacle();
        isDamaged = true;
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
    }

    public void ActivateInvincibility(float duration)
    {
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine(duration));
        }
        else
        {
            StopAllCoroutines();
            spriteRenderer.color = Color.white;
            spriteRenderer.enabled = true;
            isInvincible = false;
            isDamaged = false;
            StartCoroutine(InvincibilityCoroutine(duration));
        }
    }

    IEnumerator InvincibilityCoroutine(float duration)
    {
        isInvincible = true;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            if (isDamaged)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
            }
            else
            {
                spriteRenderer.color = new Color(1f, 1f, 1f, 0.35f);
            }

            yield return new WaitForSeconds(flickerInterval);
            elapsedTime += flickerInterval;
        }
        spriteRenderer.color = Color.white;
        spriteRenderer.enabled = true;
        isInvincible = false;
        isDamaged = false;
    }
}
