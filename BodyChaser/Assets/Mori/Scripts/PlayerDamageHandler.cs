using System.Collections;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    [SerializeField, Header("無敵時間（秒）")]
    private float invincibilityDuration = 2f;
    [SerializeField, Header("点滅の間隔（秒）")]
    private float flickerInterval = 0.1f;

    private bool isInvincible = false;
    private SpriteRenderer spriteRenderer;

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
        StartCoroutine(InvincibilityCoroutine());
    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        float elapsedTime = 0f;

        while (elapsedTime < invincibilityDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(flickerInterval);
            elapsedTime += flickerInterval;
        }

        spriteRenderer.enabled = true;
        isInvincible = false;
    }
}