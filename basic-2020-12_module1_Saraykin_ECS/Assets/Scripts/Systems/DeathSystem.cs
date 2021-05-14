using Entitas;
using System.Collections.Generic;

public class DeathSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    IGroup<GameEntity> winMessage;

    public DeathSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
        winMessage = contexts.game.GetGroup(GameMatcher.WinMessage);
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            foreach (var wm in winMessage)
            {
                if (e.isAloneEnemy) wm.isPlayerWin = true;
                if (e.isAlonePlayer) wm.isPlayerLos = true;
            }

            e.Destroy();
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isDeath;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Death.Added());
    }
}
