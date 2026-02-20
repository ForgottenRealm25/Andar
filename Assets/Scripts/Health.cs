using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public float maxHealth = 500;
    public float currentHealth;
    private SpriteRenderer sprite;
    public HealthBarUI healthBar;
    private Rigidbody2D rb;
    private Color originalColor;
    private Coroutine flashRoutine;
    private bool isKnocked;
    private void Awake()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        if (sprite != null)
            originalColor = sprite.color;
    }

    private void Start()
    {
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(float damage, bool isFinalHit = false, Transform attacker = null)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);;
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth, maxHealth);
        }

        Debug.Log("Vida de " + gameObject.name + ": " + currentHealth);

        // ⚡ Flash branco
        if (flashRoutine != null)
            StopCoroutine(flashRoutine);

        flashRoutine = StartCoroutine(FlashWhite());
        // 💥 Knockback se for último hit
        if (isFinalHit && attacker != null)
        {
            ApplyKnockback(attacker);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void ApplyKnockback(Transform attacker)
    {
        if (rb == null) return;

        Vector2 direction = (transform.position - attacker.position).normalized;

        float horizontalForce = 15f;
        float verticalForce = 5f;

        rb.linearVelocity = Vector2.zero;
        rb.AddForce(new Vector2(direction.x * horizontalForce, verticalForce), ForceMode2D.Impulse);

        StartCoroutine(KnockbackStun());
    }
    private IEnumerator KnockbackStun()
    {
        isKnocked = true;
        yield return new WaitForSeconds(0.3f);
        isKnocked = false;
    }

    private IEnumerator FlashWhite()
    {
        if (sprite == null) yield break;

        sprite.color = new Color(2f, 2f, 2f, 1f); // brilho forte

        yield return new WaitForSeconds(0.06f);

        sprite.color = originalColor;
    }
    public bool IsKnocked()
    {
        return isKnocked;
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " morreu");
        gameObject.SetActive(false);
    }
}