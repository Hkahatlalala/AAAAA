using UnityEngine;
public enum EnemyType
{
    EnemyA,
    EnemyB,
    EnemyC
}

[CreateAssetMenu(fileName = "New Enemy", menuName = "Game/Enemy")]

public class EnemyData : ScriptableObject
{
    public EnemyType enemyType;
    public string enemyName;
    public int health;
    public int damage;
    public int points;

    void Attack()
    {
        // Implement attack logic here
    }
}
