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

    private float powerAttackDamageMultiplier = 1.5f;
    private float normalAttackDamageMultiplier = 1.0f;
    private float quickAttackDamageMultiplier = 0.75f;

    private float maxRandomizationMultiplier = 1.2f;
    private float minRandomizationMultiplier = 0.8f;

    private int baseDamage = 10;

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

        float damageRandomizationFactor = Random.Range(
            minRandomizationMultiplier, maxRandomizationMultiplier);

        switch(attackType)
        {
            case AttackType.Quick:
                sword.SetDamage((int) Mathf.Round(baseDamage
                    * quickAttackDamageMultiplier * damageRandomizationFactor));
                sword.SetHitChance(quickAttackHitChance);
                animator.SetTrigger("trigger_attack_quick");
                break;
            case AttackType.Normal:
                sword.SetDamage((int) Mathf.Round(baseDamage
                    * normalAttackDamageMultiplier * damageRandomizationFactor));
                sword.SetHitChance(normalAttackHitChance);
                animator.SetTrigger("trigger_attack_normal");
                break;
            case AttackType.Power:
                sword.SetDamage((int) Mathf.Round(baseDamage
                    * powerAttackDamageMultiplier * damageRandomizationFactor));
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
