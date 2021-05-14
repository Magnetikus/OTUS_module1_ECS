using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    IGroup<GameEntity> target;

    public ShootSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
        target = contexts.game.GetGroup(GameMatcher.Target);
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.isShooter)
            {
                foreach (var t in target)
                {
                    if (t.isTarget)
                    {
                        Vector3 direction = (t.position.value - e.position.value).normalized;
                        e.ReplaceRotation(Quaternion.LookRotation(direction));
                        e.ReplaceState(CharacterState.BeginShoot);
                        e.AddTargetEntity(t);
                    }
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isShooter;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {

        return context.CreateCollector(GameMatcher.Shooter.Added());

    }
}