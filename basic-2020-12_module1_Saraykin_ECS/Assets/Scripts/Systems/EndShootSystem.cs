using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class EndShootSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    GameEntity gameLogic;
    IGroup<GameEntity> target;

    public EndShootSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
        gameLogic = contexts.game.gameLogicEntity;
        target = contexts.game.GetGroup(GameMatcher.Target);
    }
    protected override void Execute(List<GameEntity> entities)
    {
        
        foreach (var e in target)
        {
            if (!e.isDeath) e.RemoveDamage();
        }
        foreach (var e in entities)
        {
            if (e.isShooter) e.isShooter = false;
            if (e.isHunter) e.isHunter = false;
            if (e.hasTargetEntity) e.RemoveTargetEntity();
            if (e.isEndAttack) e.isEndAttack = false;
        }

        if (gameLogic.isPlayerAttack) gameLogic.isPlayerAttack = false;
        if (!gameLogic.isEnemyAttack) gameLogic.isEnemyAttack = true;
        else if (gameLogic.isEnemyAttack) gameLogic.isEndTurn = true;
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isEndShoot;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.EndShoot.Added());
    }
}
