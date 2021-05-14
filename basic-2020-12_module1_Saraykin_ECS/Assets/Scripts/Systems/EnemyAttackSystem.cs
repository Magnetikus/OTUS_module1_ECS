using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    IGroup<GameEntity> entitiesInTargetIndicator;

    public EnemyAttackSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
        entitiesInTargetIndicator = contexts.game.GetGroup(GameMatcher.TargetIndicator);
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entitiesInTargetIndicator)
        {
            
            if (e.isEnemy)
            {
                if (e.isTarget) e.isTarget = false;
                
                switch (e.weapon.value)
                {
                    case WeaponEnum.Pistol:
                        e.isShooter = true;
                        break;
                    case WeaponEnum.Bat:
                    case WeaponEnum.Fist:
                        e.isHunter = true;                        
                        break;
                }
            }

            if (e.isPlayer)
            {
                e.isTarget = true;
                e.AddDamage(0.0f);
                e.isEndShoot = false;
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isEnemyAttack;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.EnemyAttack.Added());
    }
}
