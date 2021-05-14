using Entitas;

public class InputSystem : IExecuteSystem
{
    Contexts contexts;
    GameEntity gameLogic;
    IGroup<GameEntity> canvasEntity;
    

    public InputSystem(Contexts contexts)
    {
        gameLogic = contexts.game.gameLogicEntity;
        canvasEntity = contexts.game.GetGroup(GameMatcher.Canvas);        
    }
    public void Execute()
    {
        foreach (var canvas in canvasEntity)
        {
            if (gameLogic.isEndTurn)
            {
                canvas.view.gameObject.SetActive(true);
                var panel = canvas.view.gameObject.GetComponentInChildren<ButtonPanel>();
                panel.buttonAttack.onClick.AddListener(() =>
                {
                    gameLogic.isEndTurn = false;
                    gameLogic.isPlayerAttack = true;
                    canvas.view.gameObject.SetActive(false);
                });

                panel.buttonSwitch.onClick.AddListener(() => gameLogic.isNextTarget = true);
            }
        }
    }
}

