//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity goingEntity { get { return GetGroup(GameMatcher.Going).GetSingleEntity(); } }

    public bool isGoing {
        get { return goingEntity != null; }
        set {
            var entity = goingEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isGoing = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly GoingComponent goingComponent = new GoingComponent();

    public bool isGoing {
        get { return HasComponent(GameComponentsLookup.Going); }
        set {
            if (value != isGoing) {
                var index = GameComponentsLookup.Going;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : goingComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherGoing;

    public static Entitas.IMatcher<GameEntity> Going {
        get {
            if (_matcherGoing == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Going);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGoing = matcher;
            }

            return _matcherGoing;
        }
    }
}
