using UnityEngine;

public class EnemyEntity : AbstractEntity
{
    public GameObject enemyPrefab;
    public int health;
    public WeaponEnum weapon;
    public float speed;
    
    protected override void Start()
    {
        base.Start();
        entity.isEnemy = true;
        entity.AddPrefab(enemyPrefab);        
        entity.AddHealth(health);
        entity.AddSpeed(speed);
        entity.AddState(CharacterState.Idle);
        entity.AddWeapon(weapon);                
    }
}

