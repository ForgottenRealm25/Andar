using UnityEngine;

public class Health : MonoBehaviour
{
   public int maxHealth = 1000;
   public int currentHealth;

   private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log(gameObject.name + " tomou " + damage + " de dano. Vida: " + currentHealth);

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
