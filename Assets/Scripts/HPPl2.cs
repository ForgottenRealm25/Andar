using UnityEngine;

public class HPPl2 : MonoBehaviour
{
   public float maxHealth = 500;
   public float currentHealth;
   public HealthBarUI healthBar;

   private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth);
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthBar.SetHealth(currentHealth, maxHealth);

        Debug.Log("a vida do " + gameObject.name + " é " + currentHealth + " (cerca de " + currentHealth + " de dano)");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " morreu");

        gameObject.SetActive(false);
    }
}
