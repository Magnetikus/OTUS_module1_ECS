using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EndTurnSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    IGroup<GameEntity> _player;
    IGroup<GameEntity> _enemy;    

    public EndTurnSystem (Contexts contexts) : base (contexts.game)
    {
        this.contexts = contexts;
        _player = contexts.game.GetGroup(GameMatcher.Player);
        _enemy = contexts.game.GetGroup(GameMatcher.Enemy);        
    }
    protected override void Execute(List<GameEntity> entities)
    {
        
        foreach (var e in entities)
        {
            if (e.isEnemyAttack) e.isEnemyAttack = false;
        }

        foreach (var e in _player)
        {
            
            if (e.isEndAttack) e.isEndAttack = false;
            if (e.isEndShoot) e.isEndShoot = false;
            
            if (e.isTarget) e.isTarget = false;
            if (e.hasTargetEntity) e.RemoveTargetEntity();
        }

        foreach (var e in _enemy)
        {
            if (e.isEndAttack) e.isEndAttack = false;
            if (e.isEndShoot) e.isEndShoot = false;
            
            if (e.isTarget) e.isTarget = false;
            if (e.hasTargetEntity) e.RemoveTargetEntity();
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isEndTurn;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.EndTurn.Added());
    }
}
