//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly EndAttackComponent endAttackComponent = new EndAttackComponent();

    public bool isEndAttack {
        get { return HasComponent(GameComponentsLookup.EndAttack); }
        set {
            if (value != isEndAttack) {
                var index = GameComponentsLookup.EndAttack;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : endAttackComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherEndAttack;

    public static Entitas.IMatcher<GameEntity> EndAttack {
        get {
            if (_matcherEndAttack == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EndAttack);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEndAttack = matcher;
            }

            return _matcherEndAttack;
        }
    }
}
