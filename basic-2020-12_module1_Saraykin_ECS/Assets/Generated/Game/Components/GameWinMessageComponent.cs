//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public WinMessageComponent winMessage { get { return (WinMessageComponent)GetComponent(GameComponentsLookup.WinMessage); } }
    public bool hasWinMessage { get { return HasComponent(GameComponentsLookup.WinMessage); } }

    public void AddWinMessage(UnityEngine.GameObject newGameObject) {
        var index = GameComponentsLookup.WinMessage;
        var component = (WinMessageComponent)CreateComponent(index, typeof(WinMessageComponent));
        component.gameObject = newGameObject;
        AddComponent(index, component);
    }

    public void ReplaceWinMessage(UnityEngine.GameObject newGameObject) {
        var index = GameComponentsLookup.WinMessage;
        var component = (WinMessageComponent)CreateComponent(index, typeof(WinMessageComponent));
        component.gameObject = newGameObject;
        ReplaceComponent(index, component);
    }

    public void RemoveWinMessage() {
        RemoveComponent(GameComponentsLookup.WinMessage);
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

    static Entitas.IMatcher<GameEntity> _matcherWinMessage;

    public static Entitas.IMatcher<GameEntity> WinMessage {
        get {
            if (_matcherWinMessage == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.WinMessage);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWinMessage = matcher;
            }

            return _matcherWinMessage;
        }
    }
}