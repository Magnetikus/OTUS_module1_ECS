using UnityEngine;
using Entitas;

public class CanvasEntity : MonoBehaviour
{
    Contexts contexts;
    GameEntity entity;
    public GameObject prefabCanvas;

    void Start()
    {
        contexts = Contexts.sharedInstance;
        entity = contexts.game.CreateEntity();
        entity.isCanvas = true;
        entity.AddPosition(transform.position);
        entity.AddRotation(transform.rotation);
        entity.AddPrefab(prefabCanvas);
        Destroy(gameObject);
    }    
}
