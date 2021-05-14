//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SpeedComponent speed { get { return (SpeedComponent)GetComponent(GameComponentsLookup.Speed); } }
    public bool hasSpeed { get { return HasComponent(GameComponentsLookup.Speed); } }

    public void AddSpeed(float newValue) {
        var index = GameComponentsLookup.Speed;
        var component = (SpeedComponent)CreateComponent(index, typeof(SpeedComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSpeed(float newValue) {
        var index = GameComponentsLookup.Speed;
        var component = (SpeedComponent)CreateComponent(index, typeof(SpeedComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSpeed() {
        RemoveComponent(GameComponentsLookup.Speed);
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

    static Entitas.IMatcher<GameEntity> _matcherSpeed;

    public static Entitas.IMatcher<GameEntity> Speed {
        get {
            if (_matcherSpeed == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Speed);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpeed = matcher;
            }

            return _matcherSpeed;
        }
    }
}
