using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        Invincibility,
        SpeedBoost
    }

    public ItemType type;
    public float duration = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerDamageHandler playerDamage = collision.GetComponent<PlayerDamageHandler>();
            SpeedMeter speedMeter = collision.GetComponent<SpeedMeter>();

            if (playerDamage != null && speedMeter != null)
            {
                switch (type)
                {
                    case ItemType.Invincibility:
                        playerDamage.ActivateInvincibility(duration);
                        break;
                    case ItemType.SpeedBoost:
                        speedMeter.ActivateSpeedBoost(duration);
                        break;
                }

                Destroy(gameObject);
            }
        }
    }
}
