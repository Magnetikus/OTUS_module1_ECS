//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly CanvasComponent canvasComponent = new CanvasComponent();

    public bool isCanvas {
        get { return HasComponent(GameComponentsLookup.Canvas); }
        set {
            if (value != isCanvas) {
                var index = GameComponentsLookup.Canvas;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : canvasComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherCanvas;

    public static Entitas.IMatcher<GameEntity> Canvas {
        get {
            if (_matcherCanvas == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Canvas);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCanvas = matcher;
            }

            return _matcherCanvas;
        }
    }
}