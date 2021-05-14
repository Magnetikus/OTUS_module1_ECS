using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class RemoveTargetIndicatorSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    IGroup<GameEntity> enemy;

    public RemoveTargetIndicatorSystem(Contexts contexts) : base (contexts.game)
    {
        this.contexts = contexts;
        enemy = contexts.game.GetGroup(GameMatcher.Enemy);
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in enemy)
        {
            var targetIndicator = e.view.gameObject.GetComponent<TargetIndicator>();

            if (e.isTargetIndicator)
            {
                targetIndicator.value.SetActive(true);
            }
            else targetIndicator.value.SetActive(false);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isTargetIndicator && !entity.isDeath;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.TargetIndicator.Added());
    }
}
