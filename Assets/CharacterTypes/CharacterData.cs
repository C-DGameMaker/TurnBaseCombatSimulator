using UnityEngine;

[CreateAssetMenu(fileName = "Character Data", menuName = "Character Types/Character Data")]
public class CharacterData : CharacterTypes
{
    [Header("Character Stats")]
    public int _currentHealth;
    public int _maxHealth;
    public int _strength;
    public int _speed;
    public int _def;
    public int _luck;
}
