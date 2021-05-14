using Entitas;
using System.Collections.Generic;

public class NextTargetSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    IGroup<GameEntity> enemy;
    GameEntity gameLogic;


    public NextTargetSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
        enemy = contexts.game.GetGroup(GameMatcher.Enemy);
        gameLogic = contexts.game.gameLogicEntity;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        if (enemy.count == 1)
        {
            foreach (var e in enemy)
            {
                if (!e.isAloneEnemy) e.isAloneEnemy = true;
            }
            gameLogic.isNextTarget = false;
            return;
        }
        else
        {
            List<GameEntity> enemyList = new List<GameEntity>();
            foreach (var e in enemy)
            {
                enemyList.Add(e);
            }
            int index = enemyList.FindIndex(enemy => enemy.isTargetIndicator);

            for (int i = 1; i < enemyList.Count; i++)
            {
                int next = (index + i) % enemyList.Count;
                if (!enemyList[next].isDeath)
                {
                    enemyList[index].isTargetIndicator = false;
                    enemyList[next].isTargetIndicator = true;
                    gameLogic.isNextTarget = false;
                    return;
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isNextTarget;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.NextTarget);
    }
}
