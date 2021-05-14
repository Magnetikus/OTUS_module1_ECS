using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Systems systems;

    private void Awake()
    {
        var contexts = Contexts.sharedInstance;
        var entityGameLogic = contexts.game.CreateEntity();
        entityGameLogic.isGameLogic = true;
        entityGameLogic.isEndTurn = true;

        
        systems = new Systems();
        systems.Add(new PrefabInstantiateSystem(contexts));
        
        systems.Add(new InputSystem(contexts));
        systems.Add(new PlayerAttackSystem(contexts));
        
        systems.Add(new ShootSystem(contexts));
        systems.Add(new EndShootSystem(contexts));

        systems.Add(new AttackSystem(contexts));
        systems.Add(new EndAttackSystem(contexts));

        systems.Add(new EnemyAttackSystem(contexts));
        systems.Add(new TransformApplySystem(contexts));
        systems.Add(new DamageSystem(contexts));

        systems.Add(new RemoveCharacterSystem(contexts));
        systems.Add(new NextTargetSystem(contexts));
        systems.Add(new HealthBarSystem(contexts));
        systems.Add(new RemoveTargetIndicatorSystem(contexts));
        systems.Add(new AnimationSystem(contexts));
        systems.Add(new EndTurnSystem(contexts));

        systems.Add(new DeathSystem(contexts));
        systems.Add(new PlayerWinSystem(contexts));

        systems.Initialize();
    }

    private void OnDestroy()
    {
        //systems.TearDown();
    }

    private void Update()
    {
        systems.Execute();
        //systems.Cleanup();
    }
}
