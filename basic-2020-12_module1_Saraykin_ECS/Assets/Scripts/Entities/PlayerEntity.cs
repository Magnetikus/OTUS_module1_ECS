using UnityEngine;

public class PlayerEntity : AbstractEntity
{
    public GameObject playerPrefab;
    public int health;
    public WeaponEnum weapon;
    public float speed;
    
    protected override void Start()
    {
        base.Start();
        entity.isPlayer = true;
        entity.AddPrefab(playerPrefab);
        entity.AddHealth(health);
        entity.AddSpeed(speed);
        entity.AddState(CharacterState.Idle);
        entity.AddWeapon(weapon);
        
    }
}
