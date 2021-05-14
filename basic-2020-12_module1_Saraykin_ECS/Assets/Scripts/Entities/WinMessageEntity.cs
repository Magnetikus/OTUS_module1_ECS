using UnityEngine;
using Entitas;

public class WinMessageEntity : MonoBehaviour
{
    Contexts contexts;
    GameEntity entity;
    public GameObject prefabWinMessage;

    void Start()
    {
        contexts = Contexts.sharedInstance;
        entity = contexts.game.CreateEntity();
        entity.AddWinMessage(GameObject.Instantiate(prefabWinMessage));
        entity.AddPosition(transform.position);
        entity.AddRotation(transform.rotation);
        entity.winMessage.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
