using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCharacterSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;

    public RemoveCharacterSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var view = e.view.gameObject;
            e.AddAnimation(view.GetComponent<Animator>());
        }

        foreach (var e in entities)
        {
            if (e.isEnemy)
            {
                e.isTargetIndicator = true;
                return;
            }            
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.Enemy, GameMatcher.Player));
    }
}
