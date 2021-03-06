//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly NextTargetComponent nextTargetComponent = new NextTargetComponent();

    public bool isNextTarget {
        get { return HasComponent(GameComponentsLookup.NextTarget); }
        set {
            if (value != isNextTarget) {
                var index = GameComponentsLookup.NextTarget;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : nextTargetComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherNextTarget;

    public static Entitas.IMatcher<GameEntity> NextTarget {
        get {
            if (_matcherNextTarget == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NextTarget);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNextTarget = matcher;
            }

            return _matcherNextTarget;
        }
    }
}
