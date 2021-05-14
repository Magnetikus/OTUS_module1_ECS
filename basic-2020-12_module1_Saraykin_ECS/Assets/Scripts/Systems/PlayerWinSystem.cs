using Entitas;
using System.Collections.Generic;
using UnityEngine.UI;


public class PlayerWinSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    IGroup<GameEntity> canvas;

    public PlayerWinSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
        canvas = contexts.game.GetGroup(GameMatcher.Canvas);
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in canvas)
        {
            e.view.gameObject.SetActive(false);
        }

        foreach (var e in entities)
        {
            var text = e.winMessage.gameObject.GetComponentInChildren<Text>();

            if (e.isPlayerWin)
            {
                e.winMessage.gameObject.SetActive(true);
                text.text = "Player winner";
            }
            if (e.isPlayerLos)
            {
                e.winMessage.gameObject.SetActive(true);
                text.text = "Player looser";
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isPlayerWin || entity.isPlayerLos;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.PlayerLos, GameMatcher.PlayerWin));
    }
}
