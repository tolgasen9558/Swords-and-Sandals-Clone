using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField]
    private Animator animator;
    private bool isAttacking;
    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    private void Attack()
    {
        isAttacking = true;
        animator.SetTrigger("trigger_attack");
        // TODO: Damage the opponent
        isAttacking = false;
    }
}
