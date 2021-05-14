using Entitas;
using System.Collections.Generic;

public class DamageSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    GameEntity gameLogic;

    public DamageSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
        gameLogic = contexts.game.gameLogicEntity;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.ReplaceHealth(e.health.value -= e.damage.value);

            if (e.health.value <= 0)
            {
                if (e.isEnemy)
                {
                    gameLogic.isEnemyAttack = false;
                    gameLogic.isNextTarget = true;
                }
                e.isDeath = true;
                if (e.isTarget) e.isTarget = false;
                e.ReplaceState(CharacterState.Dead);
                e.animation.value.SetBool(AnimationState.Death, true);
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasHealth && !entity.isDeath;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Damage);
    }
}
