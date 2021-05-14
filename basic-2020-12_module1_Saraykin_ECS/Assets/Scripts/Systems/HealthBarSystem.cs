using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class HealthBarSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;

    public HealthBarSystem (Contexts contexts) : base (contexts.game)
    {
        this.contexts = contexts;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {            
            var health = e.health.value;
            var view = e.view.gameObject;
            var textMech = view.GetComponentInChildren<TextMesh>();

            if (e.health.value > 0)
            {
                textMech.text = $"{health}";
            }
            else textMech.text = $" ";
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasHealth;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Health);
    }
}
