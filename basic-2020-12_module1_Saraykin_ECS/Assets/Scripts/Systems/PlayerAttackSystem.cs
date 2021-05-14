using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    IGroup<GameEntity> player;
    IGroup<GameEntity> enemy;

    public PlayerAttackSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
        player = contexts.game.GetGroup(GameMatcher.Player);
        enemy = contexts.game.GetGroup(GameMatcher.Enemy);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (!e.isPlayerAttack) return;
            foreach (var ePlayer in player)
            {
                if (player.count == 1)
                {
                    if (!ePlayer.isAlonePlayer) ePlayer.isAlonePlayer = true;
                }
                if (!ePlayer.isHunter && !ePlayer.isShooter)
                {
                    if (!ePlayer.isTargetIndicator) ePlayer.isTargetIndicator = true;
                    switch (ePlayer.weapon.value)
                    {
                        case WeaponEnum.Pistol:
                            ePlayer.isShooter = true;
                            break;
                        case WeaponEnum.Bat:
                        case WeaponEnum.Fist:
                            ePlayer.isHunter = true;                           
                            break;
                    }
                }

                foreach (var eEnemy in enemy)
                {
                    if (eEnemy.isTargetIndicator && !eEnemy.isTarget)
                    {
                        eEnemy.isTarget = true;
                        eEnemy.AddDamage(0.0f);                        
                        return;
                    }                                       
                }
            }
        }        
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isPlayerAttack;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.PlayerAttack);
    }
}

