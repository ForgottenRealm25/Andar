using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animator;
    private int attackIndex = 0;
    private float comboTimer;
    public float comboDelay = 1.2f;
    private bool CanReceiveInput = false;
    private bool inputReceive = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
           if(attackIndex == 0)
            {
                StartCombo();
            }
            else if(CanReceiveInput)
            {
                inputReceive = true;
            }
        }

        if(attackIndex > 0)
        {
            comboTimer += Time.deltaTime;
            if(comboTimer > comboDelay)
            {
                ResetCombo();
            }
        }
    }
    void StartCombo()
    {
        attackIndex = 1;
        comboTimer = 0f;

        animator.SetBool("IsAttacking", true);
        animator.SetInteger("AttackIndex", attackIndex);
    }
    public void EnableComboInput()
    {
        CanReceiveInput = true;
        inputReceive = false;
    }

    public void NextAttack()
    {
        CanReceiveInput = false;

        if(inputReceive)
        {
            attackIndex++;
            comboTimer = 0f;

            if(attackIndex > 3)
            attackIndex = 3;

            animator.SetInteger("AttackIndex", attackIndex);
        }
        else
        {
            ResetCombo();
        }
    }
    public void ResetCombo()
    {
        attackIndex = 0;

        animator.SetBool("IsAttacking", false);
        animator.SetInteger("AttackIndex", 0);
    }
}
