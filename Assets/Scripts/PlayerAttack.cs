using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private enum AttackType
    {
        Quick, Normal, Power
    };

    private Animator animator;
    private bool isAttacking;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isAttacking = false;
    }

    void Update()
    {
        HandleUserInput();
    }

    private void HandleUserInput()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Attack(AttackType.Quick);
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            Attack(AttackType.Normal);
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            Attack(AttackType.Power);
        }
    }

    private void Attack(AttackType attackType)
    {
        if(isAttacking) return;

        isAttacking = true;
        string triggerSuffix = "";
        switch(attackType)
        {
            case AttackType.Quick:
                triggerSuffix = "quick";
                break;
            case AttackType.Normal:
                triggerSuffix = "normal";
                break;
            case AttackType.Power:
                triggerSuffix = "power";
                break;
            default:
                Debug.LogError("Unknown attack type!");
                break;
        }
        animator.SetTrigger("trigger_attack_" + triggerSuffix);
    }

    private void OnAttackAnimationFinish()
    {
        isAttacking = false;
    }
}
