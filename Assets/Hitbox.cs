using UnityEngine;

public class Hitbox : MonoBehaviour
{
    BoxCollider2D col;
    public int damage = 10;
    private bool hasHit;
    
    public void ResetHit()
    {
        hasHit = false;
    }
    private void OnEnable()
    {
        hasHit = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHit) return;

        if (other.CompareTag("Enemy"))
        {
            hasHit = true;
            
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }
    public void ReactivateCollider()
    {
        col.enabled = false;
        col.enabled = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider2D>().size);
    }
}
