//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MovementTargetComponent movementTarget { get { return (MovementTargetComponent)GetComponent(GameComponentsLookup.MovementTarget); } }
    public bool hasMovementTarget { get { return HasComponent(GameComponentsLookup.MovementTarget); } }

    public void AddMovementTarget(float newSpeed) {
        var index = GameComponentsLookup.MovementTarget;
        var component = (MovementTargetComponent)CreateComponent(index, typeof(MovementTargetComponent));
        component.speed = newSpeed;
        AddComponent(index, component);
    }

    public void ReplaceMovementTarget(float newSpeed) {
        var index = GameComponentsLookup.MovementTarget;
        var component = (MovementTargetComponent)CreateComponent(index, typeof(MovementTargetComponent));
        component.speed = newSpeed;
        ReplaceComponent(index, component);
    }

    public void RemoveMovementTarget() {
        RemoveComponent(GameComponentsLookup.MovementTarget);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMovementTarget;

    public static Entitas.IMatcher<GameEntity> MovementTarget {
        get {
            if (_matcherMovementTarget == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MovementTarget);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMovementTarget = matcher;
            }

            return _matcherMovementTarget;
        }
    }
}
