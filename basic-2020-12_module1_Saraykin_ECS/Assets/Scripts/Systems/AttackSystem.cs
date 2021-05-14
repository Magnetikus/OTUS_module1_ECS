using Entitas;
using UnityEngine;

public class AttackSystem : IExecuteSystem
{
    Contexts _contexts;
    IGroup<GameEntity> _hunter;
    IGroup<GameEntity> _target;

    public AttackSystem(Contexts contexts)
    {
        _contexts = contexts;
        _hunter = _contexts.game.GetGroup(GameMatcher.Hunter);
        _target = _contexts.game.GetGroup(GameMatcher.Target);
    }

    public void Execute()
    {
        foreach (var hunter in _hunter)
        {
            foreach (var target in _target)
            {
                if (hunter.hasTargetEntity) hunter.ReplaceTargetEntity(target);
                else hunter.AddTargetEntity(target);
                hunter.ReplaceState(CharacterState.RunningToEnemy);
                if (RunTowards(hunter, target.position.value))
                {
                    switch (hunter.weapon.value)
                    {
                        case WeaponEnum.Bat:
                            hunter.ReplaceState(CharacterState.BeginAttack);
                            break;
                        case WeaponEnum.Fist:
                            hunter.ReplaceState(CharacterState.BeginPunch);
                            break;
                    }
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
