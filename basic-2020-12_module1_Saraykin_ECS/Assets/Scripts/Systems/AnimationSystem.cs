using Entitas;

public class AnimationSystem : IExecuteSystem
{
    Contexts contexts;
    IGroup<GameEntity> entities;

    public AnimationSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.Animation);
    }
    public void Execute()
    {
        foreach (var e in entities)
        {
            var animator = e.animation.value;
            var state = e.state.value;
            switch (state)
            {
                case CharacterState.Idle:
                    e.ReplaceRotation(e.originalRotation.value);
                    animator.SetFloat(AnimationState.Speed, 0.0f);
                    break;
                case CharacterState.BeginShoot:
                    animator.SetTrigger(AnimationState.Shoot);
                    e.ReplaceState(CharacterState.Shoot);                    
                    break;
                case CharacterState.Shoot:
                    e.isShooter = false;
                    break;
                case CharacterState.RunningToEnemy:
                    animator.SetFloat(AnimationState.Speed, e.speed.value);
                    break;
                case CharacterState.RunningFromEnemy:
                    animator.SetFloat(AnimationState.Speed, e.speed.value);
                    break;
                case CharacterState.BeginAttack:
                    animator.SetTrigger(AnimationState.MeleeAttack);
                    e.ReplaceState(CharacterState.Attack);
                    e.isHunter = false;
                    break;
                case CharacterState.Attack:                    
                    break;
                case CharacterState.BeginPunch:
                    animator.SetTrigger(AnimationState.Punch);
                    e.ReplaceState(CharacterState.Punch);
                    e.isHunter = false;
                    break;
                case CharacterState.Punch:                    
                    break;                                    
            }
        }
    }
}
