using UnityEngine;
using Entitas;

public class EndAttackSystem : IExecuteSystem
{
    Contexts contexts;
    IGroup<GameEntity> entity;

    public EndAttackSystem(Contexts contexts)
    {
        this.contexts = contexts;
        entity = contexts.game.GetGroup(GameMatcher.EndAttack);
    }
    public void Execute()
    {
        foreach (var e in entity)
        {
            if (e.isEndAttack)
            {
                if (e.isHunter) e.isHunter = false;
                
                if (RunTowards(e, e.originalPosition.value))
                {
                    e.ReplaceState(CharacterState.Idle);
                    e.ReplaceRotation(e.originalRotation.value);
                    e.isEndShoot = true;
                }                
            }            
        }
    }

    bool RunTowards(GameEntity hunter, Vector3 target)
    {

        var position = hunter.position.value;
        var speed = hunter.speed.value;

        Vector3 distance = target - position;
        if (distance.magnitude < 0.001f)
        {
            hunter.ReplacePosition(target);
            return true;
        }

        Vector3 direction = distance.normalized;
        hunter.ReplaceRotation(Quaternion.LookRotation(direction));
        //hunter.ReplaceRotation(Quaternion.Angle(Quaternion.Euler(direction), Quaternion.Euler(distance)));

        target -= direction * 0.5f;
        distance = (target - position);

        Vector3 step = direction * speed * Time.deltaTime;
        if (step.magnitude < distance.magnitude)
        {
            hunter.ReplacePosition(position + step);
            return false;
        }
        hunter.ReplacePosition(target);
        return true;

    }
}
