using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public enum AttackType
    {
        Quick, Normal, Power, None
    };

    [SerializeField]
    private SwordAttack sword;

    private Animator animator;
    private bool isAttacking;
    private float powerAttackHitChance = 0.33f;
    private float normalAttackHitChance = 0.50f;
    private float quickAttackHitChance = 0.66f;

    private int baseDamage = 10;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isAttacking = false;
        sword.SetDamage(baseDamage);
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

        switch(attackType)
        {
            case AttackType.Quick:
                sword.SetHitChance(quickAttackHitChance);
                animator.SetTrigger("trigger_attack_quick");
                break;
            case AttackType.Normal:
                sword.SetHitChance(normalAttackHitChance);
                animator.SetTrigger("trigger_attack_normal");
                break;
            case AttackType.Power:
                sword.SetHitChance(powerAttackHitChance);
                animator.SetTrigger("trigger_attack_power");
                break;
            case AttackType.None:
                Debug.LogError("Attack type not set before attacking!");
                break;
            default:
                Debug.LogError("Unknown attack type!");
                break;
        }
        
    }

    private void OnAttackAnimationFinish()
    {
        isAttacking = false;
    }
}
