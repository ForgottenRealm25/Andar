using UnityEngine;

public class Hitbox : MonoBehaviour
{
    BoxCollider2D col;
    public float damage = 10;
    private bool hasHit;
    private bool isFinalHit;
    private Transform attacker;
    

     private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        col.enabled = false;
    }
     public void EnableHit(bool finalHit, Transform atk)
    {
        hasHit = false;
        isFinalHit = finalHit;
        attacker = atk;
        col.enabled = true;
    }
    public void DisableHit()
    {
       col.enabled =false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!col.enabled) return;
        if (hasHit) return;

        // Pega o root de quem foi atingido
        Transform otherRoot = other.transform.root;

        // Se for o próprio dono da hitbox, ignora
        if (otherRoot == transform.root) return;

        Health health = otherRoot.GetComponent<Health>();

        if (health != null)
        {
            hasHit = true;
            health.TakeDamage(damage, isFinalHit, attacker);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider2D>().size);
    }
}
