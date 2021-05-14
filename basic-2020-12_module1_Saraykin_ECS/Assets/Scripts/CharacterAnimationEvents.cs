using UnityEngine;
using Entitas;

public class CharacterAnimationEvents : MonoBehaviour
{
    GameEntity entity;
    public Animation shootAnimation;
    
    void Start()
    {
        entity = GetComponentInParent<EntityForObject>().value;

    }

    void ShootEnd()
    {
        entity.ReplaceState(CharacterState.Idle);
        entity.isEndShoot = true;
    }

    void AttackEnd()
    {
        entity.ReplaceState(CharacterState.RunningFromEnemy);
        entity.isEndAttack = true;
    }

    void PunchEnd()
    {
        entity.ReplaceState(CharacterState.RunningFromEnemy);
        entity.isEndAttack = true;
    }

    void DoDamage()
    {        
        if (shootAnimation) shootAnimation.Play();
        entity.targetEntity.value.ReplaceDamage(1.0f);        
    }
}
