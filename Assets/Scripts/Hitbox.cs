using UnityEngine;

public class Hitbox : MonoBehaviour
{
    BoxCollider2D col;
    public int damage = 10;
    private bool hasHit;
    

     private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        col.enabled = false;
    }
     public void EnableHit()
    {
        hasHit = false;
        col.enabled = true;
    }
    public void DisableHit()
    {
       col.enabled =false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!col.enabled) return;
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

   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider2D>().size);
    }
}
